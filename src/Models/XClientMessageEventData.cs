using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace X11cs.Models;

[StructLayout(LayoutKind.Explicit)]
public unsafe struct XClientMessageEventData
{
    [FieldOffset(0)]
    public fixed sbyte b[20];
    [FieldOffset(0)]
    public fixed short s[10];
    [FieldOffset(0)]
    public fixed long l[5];
}
