using System.Runtime.InteropServices;

namespace X11cs.Models.Reply;

[StructLayout(LayoutKind.Sequential)]
public struct XEventMapRequest
{
    public uint Pad00;
    public uint Parent;
    public uint Window;
}