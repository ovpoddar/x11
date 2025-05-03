using System.Runtime.InteropServices;

namespace X11cs.Models.Reply;

[StructLayout(LayoutKind.Sequential)]
public struct XEventResizeRequest
{
    public uint Pad00;
    public uint Window;
    public ushort Width;
    public ushort Height;
}