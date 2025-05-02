using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace X11cs.Models.Display;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct Visual
{
    public XExtData* ExtData; /* hook for extension to hang data */
    public ulong VisualId;  /* visual id of this visual */
    public int Class;      /* class of screen (monochrome, etc.) */
    public ulong RedMask;
    public ulong GreenMask;
    public ulong BlueMask;  /* mask values */
    public int BitsPerRgb;   /* log base 2 of distinct color values */
    public int MapEntries;	/* color map entries */
}
