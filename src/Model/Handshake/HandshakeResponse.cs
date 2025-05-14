using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using src.Model.Handshake;

namespace src.Model.Handshake;

public struct HandshakeResponse
{
    public HandshakeStatus HandshakeStatus;
    public string? StatusMessage { get; private set; }
    public string? VendorName { get; private set; }
    public HandshakeResponseSuccessBody HandshakeResponseSuccessBody;
    public Format[]? Formats;
    public Screen[]? Screen;
    public HandshakeResponse(Socket stream)
    {
        Span<byte> scratchBuffer = stackalloc byte[8];
        stream.Receive(scratchBuffer);
        // todo: does not support in lower dotnet
        // same not another allocation can be achieve by MemoryMarshal.Cast
        // which may do a heap alloc struct (or may runtime put it in stack)
        // but it will ref to the struct. sharing same memory.
        ref var responseHead = ref Unsafe.As<byte, HandshakeResponseHead>(ref scratchBuffer[0]);
        HandshakeStatus = responseHead.HandshakeStatus;
        switch (responseHead.HandshakeStatus)
        {
            case HandshakeStatus.Failed:
                {
                    Span<byte> reason = stackalloc byte[responseHead.HandshakeResponseHeadFailed.AdditionalDataLength * 4];
                    stream.Receive(reason);
                    StatusMessage = Encoding.ASCII.GetString(reason).TrimEnd();
                    break;
                }

            case HandshakeStatus.Authenticate:
                {
                    Span<byte> reason = stackalloc byte[responseHead.HandshakeResponseHeadAuthenticate.AdditionalDataLength * 4];
                    stream.Receive(reason);
                    StatusMessage = Encoding.ASCII.GetString(reason).TrimEnd();
                    break;
                }

            case HandshakeStatus.Success:
                {
                    var totalExtraData = responseHead.HandshakeResponseHeadSuccess.AdditionalDataLength;
                    var buffer = ArrayPool<byte>.Shared.Rent(totalExtraData);
                    var totalRead = stream.Receive(buffer, 0, totalExtraData, SocketFlags.None);

                    var readingIndex = 0;
                    var bufferSlice = buffer.AsSpan(readingIndex, Marshal.SizeOf<HandshakeResponseSuccessBody>());
                    // this is tie ti the buffer. which is a ref no new allocation just as cast
                    // do not send any were else with ref.
                    ref var handshakeResponseSuccessBody = ref Unsafe.As<byte, HandshakeResponseSuccessBody>(ref bufferSlice[0]);
                    // -1  to account the string's first character
                    readingIndex += bufferSlice.Length - 1;

                    VendorName = handshakeResponseSuccessBody.VendorName;
                    readingIndex += AddPadding(handshakeResponseSuccessBody.VendorLength);

                    bufferSlice = buffer.AsSpan(readingIndex, handshakeResponseSuccessBody.FormatsNumber * Marshal.SizeOf<Format>());
                    Formats = MemoryMarshal.Cast<byte, Format>(bufferSlice).ToArray();
                    readingIndex += bufferSlice.Length;

                    Screen = new Screen[handshakeResponseSuccessBody.ScreensNumber];
                    for (var i = 0; i < Screen.Length; i++)
                    {
                        bufferSlice = buffer.AsSpan(readingIndex, Marshal.SizeOf<_Screen>());
                        Screen screen = Unsafe.As<byte, _Screen>(ref bufferSlice[0]);
                        readingIndex += bufferSlice.Length;
                        readingIndex += screen.FillTheDepth(buffer.AsSpan(readingIndex..), stream);
                        Screen[i] = screen;
                    }
                    HandshakeResponseSuccessBody = handshakeResponseSuccessBody;
                    ArrayPool<byte>.Shared.Return(buffer);

                    var readMore = (totalExtraData * 4) - totalRead;
                    var reamining = ArrayPool<byte>.Shared.Rent(readMore);
                    var read = 0;
                    while (true)
                    {
                        read += stream.Receive(reamining);
                        if (read == readMore)
                            break;
                    }
                }
                break;
            default:
                break;
        }
    }

    private static int Padding(int pad) =>
        ((4 - (pad & 3)) & 3);

    private static int AddPadding(int pad) =>
        pad + ((4 - (pad & 3)) & 3);
}
