using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace X11cs.Models.Display;

[StructLayout(LayoutKind.Sequential)]
public struct XkbMapChangesRec
{
    public ushort Changed;
    public byte MinKeyCode;
    public byte MaxKeyCode;
    public byte FirstType;
    public byte NumTypes;
    public byte FirstKeySym;
    public byte NumKeySyms;
    public byte FirstKeyAct;
    public byte NumKeyActs;
    public byte FirstKeyBehavior;
    public byte NumKeyBehaviors;
    public byte FirstKeyExplicit;
    public byte NumKeyExplicit;
    public byte FirstModmapKey;
    public byte NumModmapKeys;
    public byte FirstVmodmapKey;
    public byte NumVmodmapKeys;
    public byte Pad;
    public ushort Vmods;
}
