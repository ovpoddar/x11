using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace src.Model;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
public struct Format
{
    public byte Depth;
    public byte BitsPerPixel;
    public byte ScanLinePad; 
}