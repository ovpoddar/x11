using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace X11cs.Models.Display;
[StructLayout(LayoutKind.Sequential)]
public unsafe struct XkbShapeRec
{
    public ulong Name;
    public ushort NumOutlines;
    public ushort SzOutlines;
    public XkbOutlineRec* Outlines;
    public XkbOutlineRec* Approx;
    public XkbOutlineRec* Primary;
    public XkbBoundsRec Bounds;
}
