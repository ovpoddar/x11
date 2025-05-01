using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace X11cs.Models;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct XkbSymMapRec
{
    public fixed byte KTIndex[4];
    public byte GroupInfo;
    public byte Width;
    public ushort Offset;
}
