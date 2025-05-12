using System.Runtime.InteropServices;

namespace src.Model.Handshake;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct HandshakeResponseHeadSuccess
{
    public HandshakeStatus HandshakeStatus;
    public byte Pad0;
    public short MajorVersion;
    public short MinorVersion;
    public short AdditionalDataLength;
    // think about storing string with getter.
}