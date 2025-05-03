using System.Runtime.InteropServices;

namespace X11cs.Models.Reply;

[StructLayout(LayoutKind.Sequential)]
public struct XEventClientMessage
{
    public uint Pad00;
    public uint Window;
    public XEventClientMessageUnion U;
}