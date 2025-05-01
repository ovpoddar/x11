using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace X11cs.Models;

[StructLayout(LayoutKind.Sequential)]
public struct XkbBehavior
{
    public byte Type;
    public byte Data;
}
