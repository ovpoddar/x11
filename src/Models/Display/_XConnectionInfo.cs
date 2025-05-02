using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace X11cs.Models.Display;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct _XConnectionInfo
{
    public int Fd;
    public delegate* unmanaged[Cdecl]<XDisplay*, int, nint, void> ReadCallback;
    public nint CallData;
    public nint WatchData;
    public _XConnectionInfo* Next;
}

