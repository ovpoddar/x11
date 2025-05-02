﻿using System.Runtime.InteropServices;

namespace X11cs.Models.Reply;
[StructLayout(LayoutKind.Sequential)]
public struct XListExtensionsReply
{
    public byte Type; /* X_Reply */
    public byte NExtensions;
    public ushort SequenceNumber;
    public uint Length;
    public uint Pad2;
    public uint Pad3;
    public uint Pad4;
    public uint Pad5;
    public uint Pad6;
    public uint Pad7;
}