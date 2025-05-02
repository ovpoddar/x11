using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace X11cs.Models.Display;
[StructLayout(LayoutKind.Sequential)]
public struct XkbKeyRec
{
    public XkbKeyNameRec Name;
    public short Gap;
    public byte ShapeNDX;
    public byte ColorNDX;
}
