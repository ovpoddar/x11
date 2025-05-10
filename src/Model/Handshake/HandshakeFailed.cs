using System.Runtime.InteropServices;

namespace src.Model.Handshake;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct HandshakeFailed
{
    public HandshakeStatus HandshakeStatus;
    public byte ReasonLength;
    public short ProtocolMajorVersion;
    public short ProtocolMinorVersion;
}