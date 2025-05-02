using System.Runtime.InteropServices;

namespace X11cs.Models;

[StructLayout(LayoutKind.Sequential)]
public struct XGetInputFocusReply
{
    public byte Type; /* X_Reply */
    public byte RevertTo;
    public ushort SequenceNumber;
    public uint Length; /* 0 */
    public uint Focus;
    public uint Pad1;
    public uint Pad2;
    public uint Pad3;
    public uint Pad4;
    public uint Pad5;
}
