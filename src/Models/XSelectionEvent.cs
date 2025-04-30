using System.Runtime.InteropServices;

namespace X11cs.Models;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct XSelectionEvent
{
    public Event Type;
    public ulong Serial;   /* # of last request processed by server */
    public int SendEvent;    /* true if this came from a SendEvent request */
    public Display* Display;   /* Display the event was read from */
    public ulong Requestor;
    public ulong Selection;
    public ulong Target;
    public ulong Property;      /* ATOM or None */
    public ulong Time;
}



