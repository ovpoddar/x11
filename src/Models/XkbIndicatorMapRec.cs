using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace X11cs.Models;
[StructLayout(LayoutKind.Sequential)]
public struct XkbIndicatorMapRec
{
    public byte Flags;
    public byte WhichGroups;
    public byte Groups;
    public byte WhichMods;
    public XkbModsRec Mods;
    public uint Ctrls;
}
