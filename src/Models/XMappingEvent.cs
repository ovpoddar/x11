using System.Runtime.InteropServices;

namespace X11cs.Models;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct XMappingEvent
{
    public Event Type;
    public ulong Serial;   /* # of last request processed by server */
    public int SendEvent;    /* true if this came from a SendEvent request */
    public Display* Display;   /* Display the event was read from */
    public ulong Window;      /* unused */
    public int Request;        /* one of MappingModifier, MappingKeyboard,
				   MappingPointer */
    public int FirstKeyCode;  /* first keycode */
    public int Count;      /* defines range of change w. firstKeycode*/
}
