using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace X11cs.Models.Display;
[StructLayout(LayoutKind.Sequential)]
public unsafe struct _XConnWatchInfo
{
    public delegate* unmanaged[Cdecl]<XDisplay*, nint, int, int, nint, void> Fn;
    public nint ClientData;
    public _XConnWatchInfo* Next;
}
