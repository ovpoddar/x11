using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;

namespace src.Model;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct _Screen
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
    public BackingStores BackingStore;
    public byte SaveUnders; // Bool (0 or non-zero)
    public byte RootDepth; // bits per pixel
    public byte NumberOfDepth; // number of supported depths
}

public class Screen
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
    public BackingStores BackingStore;
    public bool SaveUnders; // Bool (0 or non-zero)
    public byte RootDepth; // bits per pixel
    public required Depth[] Depths;
    public static implicit operator Screen(_Screen depth)
    {
        var dept = new Screen()
        {
            BackingStore = depth.BackingStore,
            RootVisualId = depth.RootVisualId,
            BlackPixel = depth.BlackPixel,
            Width = depth.Width,
            Height = depth.Height,
            MWidth = depth.MWidth,
            MHeight = depth.MHeight,
            MinMaps = depth.MinMaps,
            MaxMaps = depth.MaxMaps,
            CMap = depth.CMap,
            WhitePixel = depth.WhitePixel,
            InputMask = depth.InputMask,
            RootDepth = depth.RootDepth,
            SaveUnders = depth.SaveUnders != 0,
            Root = depth.Root,
            Depths = new Depth[depth.NumberOfDepth],
        };
        return dept;
    }

    public int FillTheDepth(Span<byte> reader)
    {
        var readIndex = 0;
        for (var i = 0; i < Depths.Length; i++)
        {
            Depth depth = Unsafe.As<byte, _Depth>(ref reader[0]);
            readIndex += Marshal.SizeOf<_Depth>();

            var readLength = depth.Visuals.Length * Marshal.SizeOf<Visual>();
            if (readLength > reader.Length)
            {
                var j = 0;
                // this is total bs too but its working atleast so who cares
                while (true)
                {
                    var dept = Unsafe.As<byte, _Depth>(ref reader[readIndex]);
                    var visuals = Unsafe.As<byte, Visual>(ref reader[readIndex]);
                    if (visuals.Pad0 != 0 || readIndex > (reader.Length - 24) || (dept.Pad1 == 0 && dept.Pad0 == 0))
                        break;
                    depth.Visuals[j++] = visuals;
                    readIndex += Marshal.SizeOf<Visual>();
                }
                depth.Visuals = [.. depth.Visuals.Take(j)];
            }
            else
            {
                var bufferSlice = reader.Slice(readIndex, depth.Visuals.Length * Marshal.SizeOf<Visual>());
                depth.Visuals = MemoryMarshal.Cast<byte, Visual>(bufferSlice).ToArray();
                readIndex += bufferSlice.Length;
            }
            Depths[i] = depth;
        }
        return readIndex;
    }
}