using System.Runtime.InteropServices;

namespace X11cs.Models;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct XGenericEventCookie
{
    public Event Type;         /* of event. Always GenericEvent */
    public ulong Serial;       /* # of last request processed */
    public int SendEvent;   /* true if from SendEvent request */
    public Display* Display;     /* Display the event was read from */
    public int Extension;    /* major opcode of extension that caused the event */
    public int EventType;       /* actual event type. */
    public uint Cookie;
    public IntPtr Data;
}