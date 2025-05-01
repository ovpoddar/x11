using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace X11cs.Models;
[StructLayout(LayoutKind.Sequential)]
public unsafe struct _XConnWatchInfo
{
    public delegate* unmanaged[Cdecl]<Display*, IntPtr, int, int, IntPtr, void> Fn;
    public IntPtr ClientData;
    public _XConnWatchInfo* Next;
}
