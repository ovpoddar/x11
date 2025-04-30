using System.Runtime.InteropServices;

namespace X11cs.Models;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct XConfigureRequestEvent
{
    public Event Type;
    public ulong Serial;   /* # of last request processed by server */
    public int SendEvent;    /* true if this came from a SendEvent request */
    public Display* Display;   /* Display the event was read from */
    public ulong Parent;
    public ulong Window;
    public int X;
    public int Y;
    public int Width;
    public int Height;
    public int BorderWidth;
    public ulong Above;
    public int Detail;     /* Above, Below, TopIf, BottomIf, Opposite */
    public ulong ValueMask;
}



