using System.Runtime.InteropServices;
using System.Text;
using src.Model.Handshake;
using X11cs;

namespace src.Handler;

public static class HandshakeHandler
{
    public static HandshakeResponse MakeHandshake(Stream stream)
    {
        MakeCall(stream);
        return new HandshakeResponse(stream);
    }

    static void MakeCall(Stream stream)
    {
        var (authName, authData) = Helper.GetAuthInfo();
        var namePaddedLength = AddPadding(authName.Length);
        var scratchBufferSize = 12
            + namePaddedLength
            + AddPadding(authData.Length);
        var writingIndex = 0;
        Span<byte> scratchBuffer = stackalloc byte[scratchBufferSize];

        scratchBuffer[writingIndex++] = (byte)(BitConverter.IsLittleEndian ? 'l' : 'B');
        scratchBuffer[writingIndex++] = 0;
        MemoryMarshal.Write<ushort>(scratchBuffer[writingIndex..], 11);
        writingIndex += 2;
        MemoryMarshal.Write<ushort>(scratchBuffer[writingIndex..], 0);
        writingIndex += 2;
        MemoryMarshal.Write(scratchBuffer[writingIndex..], (ushort)authName.Length);
        writingIndex += 2;
        MemoryMarshal.Write(scratchBuffer[writingIndex..], (ushort)authData.Length);
        writingIndex += 2;
        MemoryMarshal.Write<ushort>(scratchBuffer[writingIndex..], 0);
        writingIndex += 2;
        Encoding.ASCII.GetBytes(authName, scratchBuffer[writingIndex..]);
        writingIndex += namePaddedLength;
        Encoding.ASCII.GetBytes(authData, scratchBuffer[writingIndex..]);
        writingIndex += authData.Length;
        stream.Write(scratchBuffer);
    }

    private static int AddPadding(int pad) =>
        pad + ((4 - (pad & 3)) & 3);
}