using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace X11cs.Models;
[StructLayout(LayoutKind.Sequential)]
public unsafe struct XRMMethods
{
    public delegate* unmanaged[Cdecl]<IntPtr, void> MbInit;
    public delegate* unmanaged[Cdecl]<IntPtr, sbyte*, int*, sbyte> MbChar;
    public delegate* unmanaged[Cdecl]<IntPtr, void> MbFinish;
    public delegate* unmanaged[Cdecl]<IntPtr, IntPtr> LcName;
    public delegate* unmanaged[Cdecl]<IntPtr, void> Destroy;
}
