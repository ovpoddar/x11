using System.Runtime.InteropServices;
using X11cs.Models.Display;
namespace X11cs.Models.Event;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct XSelectionEvent
{
    public EventType Type;
    public ulong Serial;   /* # of last request processed by server */
    public int SendEvent;    /* true if this came from a SendEvent request */
    public XDisplay* Display;   /* XDisplay the event was read from */
    public ulong Requestor;
    public ulong Selection;
    public ulong Target;
    public ulong Property;      /* ATOM or None */
    public ulong Time;
}



