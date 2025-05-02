using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace X11cs.Models.Event.Event;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 192)]
public unsafe struct _XEvent
{
    public fixed byte Context[192];
}