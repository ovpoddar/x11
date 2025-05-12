using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace src.Model;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Screen
{
    public uint Root; // Window (XID, usually ulong)
    public uint CMap; // Colormap
    public uint WhitePixel; // pixel value for white
    public uint BlackPixel; // pixel value for black
    public int InputMask; // event mask
    public ushort Width; // screen width in pixels
    public ushort Height; // screen height in pixels
    public ushort MWidth; // width in millimeters
    public ushort MHeight; // height in millimeters
    public ushort MinMaps; // min colormaps
    public ushort MaxMaps; // max colormaps
    public uint RootVisualId; // Visual*
    public BackingStores BackingStore; // enum: Never, WhenMapped, Always
    public byte SaveUnders; // Bool (0 or non-zero)
    public byte RootDepth; // bits per pixel
    public byte NDepths; // number of supported depths
    public byte NumberOfDepth;
}