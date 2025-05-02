using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace X11cs.Models;
[StructLayout(LayoutKind.Sequential)]
public unsafe struct _XInternalAsync
{
    public _XInternalAsync* Next;
    /*
     * handler arguments:
     * rep is the generic reply that caused this handler
     * to be invoked.  It must also be passed to _XGetAsyncReply.
     * buf and len are opaque values that must be passed to
     * _XGetAsyncReply or _XGetAsyncData.
     * data is the closure stored in this struct.
     * The handler returns True iff it handled this reply.
     */
    public delegate* unmanaged[Cdecl]<Display*, XReply*, sbyte*, int, IntPtr, int> Handler;
    public IntPtr Data;
}
