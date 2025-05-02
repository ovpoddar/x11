using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using X11cs.Models.Event;

namespace X11cs.Models.Display;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct _XExtension
{
    public _XExtension* Next;
    public XExtCodes Codes;
    public delegate* unmanaged[Cdecl]<XDisplay*, nint, XExtCodes*, int> CreateGC;
    public delegate* unmanaged[Cdecl]<XDisplay*, nint, XExtCodes*, int> CopyGC;
    public delegate* unmanaged[Cdecl]<XDisplay*, nint, XExtCodes*, int> FlushGC;
    public delegate* unmanaged[Cdecl]<XDisplay*, nint, XExtCodes*, int> FreeGC;
    public delegate* unmanaged[Cdecl]<XDisplay*, nint, XExtCodes*, int> CreateFont;
    public delegate* unmanaged[Cdecl]<XDisplay*, nint, XExtCodes*, int> FreeFont;
    public delegate* unmanaged[Cdecl]<XDisplay*, XExtCodes*, int> CloseDisplay;
    public delegate* unmanaged[Cdecl]<XDisplay*, nint, XExtCodes*, int*, int> Error;
    public delegate* unmanaged[Cdecl]<XDisplay*, int, XExtCodes*, nint, int, nint> ErrorString;
    public nint Name;
    public delegate* unmanaged[Cdecl]<XDisplay*, XErrorEvent*, nint, void> ErrorValues;
    public delegate* unmanaged[Cdecl]<XDisplay*, XExtCodes*, nint, long, void> BeforeFlush;
    public _XExtension* NextFlush;
    public string? GetName() =>
        Marshal.PtrToStringAnsi(Name);
}

