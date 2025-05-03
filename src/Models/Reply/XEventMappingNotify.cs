using System.Runtime.InteropServices;

namespace X11cs.Models.Reply;

[StructLayout(LayoutKind.Sequential)]
public struct XEventMappingNotify
{
    public uint Pad00;
    public byte Request;
    public byte FirstKeyCode;
    public byte Count;
    public byte Pad1;
}