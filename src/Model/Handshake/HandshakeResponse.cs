using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
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
    public Screen? Screen;
    public Depth[]? Depths;
    public HandshakeResponse(Stream stream)
    {
        Span<byte> scratchBuffer = stackalloc byte[8];
        stream.ReadExactly(scratchBuffer);
        // todo: does not support in lower dotnet
        // same not another allocation can be achieve by MemoryMarshal.Cast
        // which may do a heap alloc struct (or may runtime put it in stack)
        // but it will ref to the struct. sharing same memory.
        // todo: want to change how its get processed.
        // for starter not doing another read for the string message.
        // test it before process
        ref var responseHead = ref Unsafe.As<byte, HandshakeResponseHead>(ref scratchBuffer[0]);
        HandshakeStatus = responseHead.HandshakeStatus;
        switch (responseHead.HandshakeStatus)
        {
            case HandshakeStatus.Failed:
                {
                    Span<byte> reason = stackalloc byte[responseHead.HandshakeResponseHeadFailed.AdditionalDataLength * 4];
                    stream.ReadExactly(reason);
                    StatusMessage = Encoding.ASCII.GetString(reason).TrimEnd();
                    break;
                }

            case HandshakeStatus.Authenticate:
                {
                    Span<byte> reason = stackalloc byte[responseHead.HandshakeResponseHeadAuthenticate.AdditionalDataLength * 4];
                    stream.ReadExactly(reason);
                    StatusMessage = Encoding.ASCII.GetString(reason).TrimEnd();
                    break;
                }

            case HandshakeStatus.Success:
                {
                    var totalExtraData = responseHead.HandshakeResponseHeadSuccess.AdditionalDataLength;
                    var buffer = ArrayPool<byte>.Shared.Rent(totalExtraData);
                    stream.ReadExactly(buffer, 0, totalExtraData);
                    var readingIndex = 0;
                    var bufferSlice = buffer.AsSpan(readingIndex, Marshal.SizeOf<HandshakeResponseSuccessBody>());

                    HandshakeResponseSuccessBody = Unsafe.As<byte, HandshakeResponseSuccessBody>(ref bufferSlice[0]);
                    readingIndex += Marshal.SizeOf<HandshakeResponseSuccessBody>();

                    bufferSlice = buffer.AsSpan(readingIndex, HandshakeResponseSuccessBody.VendorLength);
                    VendorName = Encoding.ASCII.GetString(bufferSlice);
                    readingIndex += AddPadding(bufferSlice.Length);

                    bufferSlice = buffer.AsSpan(readingIndex, HandshakeResponseSuccessBody.FormatsNumber * 8);
                    Formats = MemoryMarshal.Cast<byte, Format>(bufferSlice).ToArray();
                    readingIndex += bufferSlice.Length;

                    bufferSlice = buffer.AsSpan(readingIndex, Marshal.SizeOf<Screen>());
                    Screen = Unsafe.As<byte, Screen>(ref bufferSlice[0]);
                    readingIndex += Marshal.SizeOf<Screen>();

                    Depths = new Depth[Screen.Value.NumberOfDepth];
                    for (int i = 0; i < Depths.Length; i++)
                    {
                        bufferSlice = buffer.AsSpan(readingIndex, Marshal.SizeOf<_Depth>());
                        Depth depth = Unsafe.As<byte, _Depth>(ref bufferSlice[0]);
                        readingIndex += Marshal.SizeOf<_Depth>();

                        var visualSize = depth.Visuals.Length * Marshal.SizeOf<Visual>();
                        bufferSlice = buffer.AsSpan(readingIndex, visualSize);                        
                        depth.Visuals = MemoryMarshal.Cast<byte, Visual>(bufferSlice).ToArray();
                        readingIndex += visualSize;
                        
                        Depths[i] = depth;
                    }

                    ArrayPool<byte>.Shared.Return(buffer);
                }
                break;
            default:
                break;
        }
    }



    private static int AddPadding(int pad) =>
        pad + ((4 - (pad & 3)) & 3);
}
