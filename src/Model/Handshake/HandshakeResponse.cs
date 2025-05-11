using System;
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
    public HandshakeResponse(Stream stream)
    {
        Span<byte> scratchBuffer = stackalloc byte[8];
        stream.ReadExactly(scratchBuffer);
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
                    {
                        Span<byte> reason = stackalloc byte[32];
                        stream.ReadExactly(reason);
                        // this is a copy not a ref.
                        HandshakeResponseSuccessBody = Unsafe.As<byte, HandshakeResponseSuccessBody>(ref scratchBuffer[0]);
                    }
                    {
                        Span<byte> reason = stackalloc byte[responseHead.HandshakeResponseHeadSuccess.AdditionalDataLength - 32];
                        stream.ReadExactly(reason);
                        System.Console.WriteLine(String.Join(", ", reason.ToArray()));
                    }
                }
                break;
            default:
                break;
        }
    }
}
