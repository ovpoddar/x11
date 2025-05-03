using System.Runtime.InteropServices;

namespace X11cs.Models.Reply;

[StructLayout(LayoutKind.Sequential)]
public struct XEventDestroyNotify
{
    public uint Pad00;
    public uint Event;
    public uint Window;
}