using System.Runtime.InteropServices;
using X11cs.Models.Display;

namespace X11cs.Models.Event;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct XNoExposeEvent
{
    public EventType Type;
    public ulong Serial;   /* # of last request processed by server */
    public int SendEvent;    /* true if this came from a SendEvent request */
    public XDisplay* Display;   /* XDisplay the event was read from */
    public ulong Drawable;
    public int MajorCode;     /* core is CopyArea or CopyPlane */
    public int MinorCode;		/* not defined in the core */
}



