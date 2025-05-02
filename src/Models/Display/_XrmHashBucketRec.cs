using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace X11cs.Models.Display;
[StructLayout(LayoutKind.Sequential)]
public unsafe struct _XrmHashBucketRec
{
    public nint Table; // todo: find way to do this _NTable
    public nint MbState;
    public XRMMethods* Methods;
    public nint LInfo; // todo: find way to do this LockInfoRec
}
