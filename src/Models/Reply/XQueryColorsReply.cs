using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace X11cs.Models.Reply;

[StructLayout(LayoutKind.Sequential)]
public struct XQueryColorsReply
{
    public byte Type; /* X_Reply */
    public byte Pad1;
    public ushort SequenceNumber;
    public uint Length;
    public ushort NColors;
    public ushort Pad2;
    public uint Pad3;
    public uint Pad4;
    public uint Pad5;
    public uint Pad6;
    public uint Pad7;
}