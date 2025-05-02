using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace X11cs.Models.Display;
[StructLayout(LayoutKind.Sequential)]
public struct XkbOverlayKeyRec
{
    public XkbKeyNameRec Over;
    public XkbKeyNameRec Under;
}
