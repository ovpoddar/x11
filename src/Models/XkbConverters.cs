using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace X11cs.Models;
[StructLayout(LayoutKind.Sequential)]
public unsafe struct XkbConverters
{
    public delegate* unmanaged[Cdecl]<ulong, ulong, char*, int, int*, int> KSToMB;
    public IntPtr KSToMBPriv;
    public delegate* unmanaged[Cdecl]<ulong, char*, int, int*, ulong> MBToKS;
    public IntPtr MBToKSPriv;
    public delegate* unmanaged[Cdecl]<ulong, ulong> KSToUpper;
}
