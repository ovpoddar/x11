using System.Runtime.InteropServices;

namespace X11cs.Models;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct XCBGenericEvent
{
    public byte ResponseType;
    public byte Pad0;
    public ushort Sequence;
    public fixed uint Pad[7];
    public uint FullSequence;
}