using System.Runtime.InteropServices;

namespace X11cs.Models.Display;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct PendingRequest
{
    public PendingRequest* Next;
    public ulong Sequence;
    public uint ReplyWaiter;
}
