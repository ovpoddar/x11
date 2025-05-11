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
    public int ReleaseNumber { get; set; }
    public int ResourceIDBase { get; set; }
    public int ResourceIDMask { get; set; }
    public int MotionBufferSize { get; set; }
    public short VendorLength { get; set; }
    public short MaxRequestLength { get; set; }
    public byte ScreensNumber { get; set; }
    public byte FormatsNumber { get; set; }
    public byte ImageByteOrder { get; set; }
    public byte BitmapBitOrder { get; set; }
    public byte BitmapScanLineUnit { get; set; }
    public byte BitmapScanLinePad { get; set; }
    public byte MinKeyCode { get; set; }
    public byte MaxKeyCode { get; set; }
    public int Padding { get; set; }
}
