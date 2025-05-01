using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace X11cs.Models;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct XkbDescRec
{
    public Display* Dpy;
    public ushort Flags;
    public ushort DeviceSpec;
    public byte MinKeyCode;
    public byte MaxKeyCode;

    public XkbControlsRec* Ctrls;
    public XkbServerMapRec* Server;
    public XkbClientMapRec* Map;
    public IntPtr Indicators; // todo: need to a way to implement XkbIndicatorRec
    public XkbNamesRec* Names;
    public IntPtr Compat; // todo: need to a way to implement XkbCompatMapRec
    public _XkbGeometry* Geom;
}
