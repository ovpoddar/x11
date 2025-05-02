﻿using System.Runtime.InteropServices;

namespace X11cs.Models.Display;

[StructLayout(LayoutKind.Sequential)]
public struct XCharInfo
{
    public short LeftSideBearing;
    public short RightSideBearing;
    public short CharacterWidth;
    public short Ascent;
    public short Descent;
    public ushort Attributes;
}
