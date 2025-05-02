using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace X11cs.Models.Display;
[StructLayout(LayoutKind.Sequential)]
public unsafe struct XkbOverlayRowRec
{
    public ushort RowUnder;
    public ushort NumKeys;
    public ushort SzKeys;
    public XkbOverlayKeyRec* Keys;
}
