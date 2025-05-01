using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace X11cs.Models;
[StructLayout(LayoutKind.Sequential)]
public struct XkbModsRec
{
    public byte Mask; /* effective mods */
    public byte RealMods;
    public ushort VMods;
}
