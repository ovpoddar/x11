using System.Runtime.InteropServices;

namespace X11cs.Models.Reply;

[StructLayout(LayoutKind.Sequential)]
public struct XEventNoExposure
{
    public uint Pad00;
    public uint Drawable;
    public ushort MinorEvent;
    public byte MajorEvent;
    public byte BPad;
}