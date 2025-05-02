using System.Runtime.InteropServices;

namespace X11cs.Models.Display;
[StructLayout(LayoutKind.Sequential)]
public unsafe struct XkbKeyNameRec
{
    public fixed sbyte Name[4];
}