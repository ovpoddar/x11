using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace X11cs.Models;

[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
public unsafe struct FreeFuncs
{
    public delegate* unmanaged[Cdecl]<Display*, void> Atoms;
    public delegate* unmanaged[Cdecl]<XModifierKeymap*, void> ModifierMap;
    public delegate* unmanaged[Cdecl]<Display*, void> KeyBindings;
    public delegate* unmanaged[Cdecl]<Display*, void> ContextDB;
    public delegate* unmanaged[Cdecl]<Display*, void> DefaultCCCs;
    public delegate* unmanaged[Cdecl]<Display*, void> ClientCmaps;
    public delegate* unmanaged[Cdecl]<Display*, void> IntensityMaps;
    public delegate* unmanaged[Cdecl]<Display*, void> IMFilters;
    public delegate* unmanaged[Cdecl]<Display*, void> XKB;

}
