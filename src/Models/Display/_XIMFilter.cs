using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using X11cs.Models.Event.Event;

namespace X11cs.Models.Display;
[StructLayout(LayoutKind.Sequential)]
public unsafe struct _XIMFilter
{
    public _XIMFilter* Next;
    public ulong Window;
    public ulong EventMask;
    public int StartType;
    public int EndType;
    public delegate* unmanaged[Cdecl]<XDisplay*, ulong, XEvent*, nint, int> Filter;
    public nint ClientData;
}
