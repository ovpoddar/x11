using System.Runtime.InteropServices;

namespace X11cs.Models.Reply;

[StructLayout(LayoutKind.Sequential)]
public struct XEventSelectionNotify
{
    public uint Pad00;
    public uint Time;
    public uint Requestor;
    public uint Selection;
    public uint Target;
    public uint Property;
}