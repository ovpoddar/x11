using System.Runtime.InteropServices;

namespace src.Model.Handshake;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct HandshakeResponseHeadFailed
{
    public HandshakeStatus HandshakeStatus;
    public byte ReasonLength;
    public short MajorVersion;
    public short MinorVersion;
    public short AdditionalDataLength;
}
