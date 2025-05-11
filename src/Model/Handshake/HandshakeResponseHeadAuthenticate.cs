using System.Runtime.InteropServices;

namespace src.Model.Handshake;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public unsafe struct HandshakeResponseHeadAuthenticate
{
    public HandshakeStatus HandshakeStatus;
    public fixed byte Pad[5];
    public short AdditionalDataLength;
}
