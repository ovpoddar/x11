using System.Runtime.InteropServices;

namespace X11cs.Models.Reply;

[StructLayout(LayoutKind.Sequential)]
public struct XEventSelectionRequest
{
    public uint Pad00;
    public uint Time;
    public uint Owner;
    public uint Requestor;
    public uint Selection;
    public uint Target;
    public uint Property;
}