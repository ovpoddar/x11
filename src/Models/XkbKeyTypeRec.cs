using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace X11cs.Models;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct XkbKeyTypeRec
{
    public XkbModsRec Mods;
    public byte NumLevels;
    public byte MapCount;
    /* map is an array of mapCount XkbKTMapEntryRec structs */
    public XkbKTMapEntryRec* Map;
    /* preserve is an array of mapCount XkbModsRec structs */
    public XkbModsRec* Preserve;
    public ulong Name;
    /* levelNames is an array of numLevels Atoms */
    public ulong* LevelNames;
}
