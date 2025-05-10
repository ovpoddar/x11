using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace src.Model.Handshake;

[StructLayout(LayoutKind.Explicit)]
public struct HandshakeResponse
{
    [FieldOffset(0)]
    public HandshakeStatus Status;
    [FieldOffset(0)]
    public HandshakeFailed Failed;
    [FieldOffset(0)]
    public HandshakeSuccess Success;
    [FieldOffset(0)]
    public HandshakeAuthenticate Authenticate;
}
