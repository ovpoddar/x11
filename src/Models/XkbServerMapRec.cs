using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace X11cs.Models;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct XkbServerMapRec
{
    public ushort NumActs;
    public ushort SizeActs;
    public IntPtr Acts; // todo: need to implement this XkbAction

    /* behaviors, keyActs, explicit, & vmodmap are all arrays with
	   (xkb->maxKeyCode + 1) entries allocated for each. */
    public XkbBehavior* Behaviors;
    public ushort* KeyActs;
    public byte* Explicit;
    public fixed byte VMods[16];
    public ushort* VModMap;
}
