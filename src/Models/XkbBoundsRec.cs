using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace X11cs.Models;
[StructLayout(LayoutKind.Sequential)]
public struct XkbBoundsRec
{
    public short X1; 
    public short Y1;
    public short X2; 
    public short Y2;
}
