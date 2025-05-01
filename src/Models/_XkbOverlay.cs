using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace X11cs.Models;
[StructLayout(LayoutKind.Sequential)]
public unsafe struct _XkbOverlay
{
    public ulong Name;
    public XkbSectionRec* SectionUnder;
    public ushort NumRows;
    public ushort SzRows;
    public XkbOverlayRowRec* Rows;
    public XkbBoundsRec* Bounds;
}
