using System.Runtime.InteropServices;

namespace X11cs.Models.Reply;

[StructLayout(LayoutKind.Sequential)]
public struct XEventClientMessageUnionL
{
    public uint Type;
    public int Longs0;
    public int Longs1;
    public int Longs2;
    public int Longs3;
    public int Longs4;
}