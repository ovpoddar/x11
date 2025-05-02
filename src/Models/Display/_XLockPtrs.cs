using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace X11cs.Models.Display;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct _XLockPtrs
{
    public delegate* unmanaged[Cdecl]<XDisplay*, nint, int, void> LockDisplay;

    public delegate* unmanaged[Cdecl]<XDisplay*, nint, int, void> UnlockDisplay;
}

