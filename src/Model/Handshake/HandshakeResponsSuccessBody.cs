using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace src.Model.Handshake;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct HandshakeResponseSuccessBody
{
    public uint ReleaseNumber { get; set; }
    public uint ResourceIDBase { get; set; }
    public uint ResourceIDMask { get; set; }
    public uint MotionBufferSize { get; set; }
    public short VendorLength { get; set; }
    public ushort MaxRequestLength { get; set; }
    public byte ScreensNumber { get; set; }
    public byte FormatsNumber { get; set; }
    public ImageOrder ImageByteOrder { get; set; }
    public BitOrder BitmapBitOrder { get; set; }
    public byte BitmapScanLineUnit { get; set; }
    public byte BitmapScanLinePad { get; set; }
    public byte MinKeyCode { get; set; }
    public byte MaxKeyCode { get; set; }
    public int Padding { get; set; }
}
