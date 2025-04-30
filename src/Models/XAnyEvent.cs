using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace X11cs.Models;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct XAnyEvent
{
    public Event Type;
    public ulong Serial;   /* # of last request processed by server */
    public bool SendEvent;    /* true if this came from a SendEvent request */
    public Display* Display;/* Display the event was read from */
    public ulong Window;	/* window on which event was requested in event mask */
}
