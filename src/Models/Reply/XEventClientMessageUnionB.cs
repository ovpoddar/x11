using System.Runtime.InteropServices;

namespace X11cs.Models.Reply;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct XEventClientMessageUnionB
{
    public uint Type;
    public fixed byte Bytes[20];
}