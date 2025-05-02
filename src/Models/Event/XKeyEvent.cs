using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using X11cs.Models.Display;

namespace X11cs.Models.Event;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct XKeyEvent
{
    public EventType Type;       /* of event */
    public ulong Serial;   /* # of last request processed by server */
    public int SendEvent;    /* true if this came from a SendEvent request */
    public XDisplay* Display;   /* XDisplay the event was read from */
    public ulong Window;          /* "event" window it is reported relative to */
    public ulong Root;            /* root window that the event occurred on */
    public ulong SubWindow;   /* child window */
    public ulong Time;      /* milliseconds */
    public int X;
    public int Y;       /* pointer x, y coordinates in event window */
    public int XRoot;
    public int YRoot; /* coordinates relative to root */
    public uint State; /* key or button mask */
    public uint KeyCode;   /* detail */
    public int SameScreen;	/* same screen flag */
}
