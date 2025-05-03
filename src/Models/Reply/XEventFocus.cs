using System.Runtime.InteropServices;

namespace X11cs.Models.Reply;

[StructLayout(LayoutKind.Sequential)]
public struct XEventFocus
{
    public uint Pad00;
    public uint Window;
    public byte Mode; // really XMode 
    public byte Pad1;
    public byte Pad2;
    public byte Pad3;
}