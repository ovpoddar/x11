using System.Runtime.InteropServices;
using System.Text;
using src.Model.Handshake;
using X11cs;

namespace src.Handler;

public static class HandshakeHandler
{
    public static HandshakeResponse MakeHandshake(Stream stream)
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
        MemoryMarshal.Write<short>(scratchBuffer[writingIndex..], 11);
        writingIndex += 2;
        MemoryMarshal.Write<short>(scratchBuffer[writingIndex..], 0);
        writingIndex += 2;
        MemoryMarshal.Write(scratchBuffer[writingIndex..], (short)authName.Length);
        writingIndex += 2;
        MemoryMarshal.Write(scratchBuffer[writingIndex..], (short)authData.Length);
        writingIndex += 2;
        MemoryMarshal.Write<short>(scratchBuffer[writingIndex..], 0);
        writingIndex += 2;
        Encoding.ASCII.GetBytes(authName, scratchBuffer[writingIndex..]);
        writingIndex += namePaddedLength;
        Encoding.ASCII.GetBytes(authData, scratchBuffer[writingIndex..]);
        writingIndex += authData.Length;
        stream.Write(scratchBuffer);

        byte[] c = new byte[1024];

        var read = stream.Read(c, 0, c.Length);
        Console.WriteLine(string.Join(",", c.Take(read)));

        return default;
    }

    private static int AddPadding(int pad) =>
        pad + ((4 - (pad & 3)) & 3);
}