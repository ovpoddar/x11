using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using X11cs.Models.Event.Event;

namespace X11cs.Models.Display;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct SQEvent
{
    public SQEvent* Next;
    public _XEvent Event;
    public ulong QSerialNumber;
}
