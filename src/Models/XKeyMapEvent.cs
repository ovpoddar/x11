﻿using System.Runtime.InteropServices;

namespace X11cs.Models;

/* generated on EnterWindow and FocusIn  when KeyMapState selected */
[StructLayout(LayoutKind.Sequential)]
public unsafe struct XKeyMapEvent
{
    public Event Type;
    public ulong Serial;   /* # of last request processed by server */
    public int SendEvent;    /* true if this came from a SendEvent request */
    public Display* Display;   /* Display the event was read from */
    public ulong Window;
    public fixed char keyVector[32];
}



