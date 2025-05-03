using System.Runtime.InteropServices;

namespace X11cs.Models.Reply;

[StructLayout(LayoutKind.Sequential)]
public struct XEventVisibility
{
    public uint Pad00;
    public uint Window;
    public byte State;
    public byte Pad1;
    public byte Pad2;
    public byte Pad3;
}
