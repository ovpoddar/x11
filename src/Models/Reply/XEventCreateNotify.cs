using System.Runtime.InteropServices;

namespace X11cs.Models.Reply;

[StructLayout(LayoutKind.Sequential)]
public struct XEventCreateNotify

{
    public uint Pad00;
    public uint Parent;
    public uint Window;
    public short X;
    public short Y;
    public ushort Width;
    public ushort Height;
    public ushort BorderWidth;
    public byte Override;
    public byte BPad;
}