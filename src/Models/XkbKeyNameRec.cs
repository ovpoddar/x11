using System.Runtime.InteropServices;

namespace X11cs.Models;
[StructLayout(LayoutKind.Sequential)]
public unsafe struct XkbKeyNameRec
{
    public fixed sbyte Name[4];
}