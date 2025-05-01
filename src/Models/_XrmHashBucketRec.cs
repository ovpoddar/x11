using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace X11cs.Models;
[StructLayout(LayoutKind.Sequential)]
public unsafe struct _XrmHashBucketRec
{
    public IntPtr Table; // todo: find way to do this _NTable
    public IntPtr MbState;
    public XRMMethods* Methods;
    public IntPtr LInfo; // todo: find way to do this LockInfoRec
}
