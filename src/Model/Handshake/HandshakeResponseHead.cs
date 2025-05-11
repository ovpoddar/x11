using System.Runtime.InteropServices;

namespace src.Model.Handshake;

[StructLayout(LayoutKind.Explicit, Pack = 1, Size = 8)]
public ref struct HandshakeResponseHead
{
    [FieldOffset(0)]
    public HandshakeStatus HandshakeStatus;
    [FieldOffset(0)]
    public HandshakeResponseHeadSuccess HandshakeResponseHeadSuccess;
    [FieldOffset(0)]
    public HandshakeResponseHeadFailed HandshakeResponseHeadFailed;
    [FieldOffset(0)]
    public HandshakeResponseHeadAuthenticate HandshakeResponseHeadAuthenticate;
}
