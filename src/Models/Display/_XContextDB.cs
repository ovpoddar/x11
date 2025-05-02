using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace X11cs.Models.Display;
[StructLayout(LayoutKind.Sequential)]
public unsafe struct _XContextDB
{
    public TableEntry* Table;		/* Pointer to array of hash entries. */
    public int Mask;			/* Current size of hash table minus 1. */
    public int Numentries;		/* Number of entries currently in table. */
    public nint LInfo; // todo: find a way to get this
}
