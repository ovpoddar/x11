using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace src.Model;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct _Depth
{
    public byte DepthValue;
    public byte Pad0;
    public short VisualsLength;
    public int Pad1;
}

public class Depth
{
    public byte DepthValue;
    public required Visual[] Visuals;

    public static implicit operator Depth(_Depth depth)
    {
        var dept = new Depth()
        {
            DepthValue = depth.DepthValue,
            Visuals = new Visual[depth.VisualsLength]
        };
        System.Console.WriteLine(depth.VisualsLength);
        return dept;
    }
}