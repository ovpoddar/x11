using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace X11cs.Models;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct XModifierKeymap
{
    public int MaxKeyPerMod;  /* The server's max # of keys per modifier */
    public byte* ModifierMap;	/* An 8 by maxKeyPerMod array of modifiers */
}
