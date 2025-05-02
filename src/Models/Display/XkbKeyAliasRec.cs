using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace X11cs.Models.Display;
[StructLayout(LayoutKind.Sequential)]
public unsafe struct XkbKeyAliasRec
{
    public fixed sbyte Real[4];
    public fixed sbyte Alias[4];
}
