using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace X11cs.Models.Display;
[StructLayout(LayoutKind.Sequential)]
public unsafe struct XkbRowRec
{
    public short Top;
    public short Left;
    public ushort NumKeys;
    public ushort SzKeys;
    public int Vertical;
    public XkbKeyRec* Keys;
    public XkbBoundsRec Bounds;
}
