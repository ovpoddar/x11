using System.Runtime.InteropServices;

namespace X11cs.Models;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct _X11XCBPrivate
{
    public IntPtr Connection;
    public PendingRequest* PendingRequests;
    public PendingRequest* PendingRequestsTail;
    public XCBGenericEvent* nextEvent;
    public IntPtr NextResponse;
    public IntPtr RealBufmax;
    public IntPtr ReplyData;
    public int ReplyLength;
    public int ReplyConsumed;
    public ulong LastFlushed;
    public XEventQueueOwner EventOwner;
    public ulong NextXid;

    /* handle simultaneous threads waiting for responses */
    public IntPtr EventNotify;
    public int EventWaiter;
    public IntPtr ReplyNotify;
}