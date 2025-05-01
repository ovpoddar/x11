using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace X11cs.Models;
[StructLayout(LayoutKind.Sequential)]
public unsafe struct Depth
{
    public int DepthValue;      /* this depth (Z) of the depth */
    public int NVisuals;       /* number of Visual types at this depth */
    public Visual* Visuals;	/* list of visuals possible at this depth */
}
