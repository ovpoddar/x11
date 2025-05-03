using System.Runtime.InteropServices;

namespace X11cs.Models.Reply;

[StructLayout(LayoutKind.Sequential)]
public struct XEventMapNotify
{
    public uint Pad00;
    public uint Event;
    public uint Window;
    public byte Override;
    public byte Pad1;
    public byte Pad2;
    public byte Pad3;
}