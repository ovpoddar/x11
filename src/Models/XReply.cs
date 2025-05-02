using System.Runtime.InteropServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace X11cs.Models;
[StructLayout(LayoutKind.Explicit, Size = 32)]
public struct xReply
{
    [FieldOffset(0)]
    public XGenericReply Generic;
    [FieldOffset(0)]
    public XGetGeometryReply Geom;
    [FieldOffset(0)] 
    public XQueryTreeReply Tree;
    [FieldOffset(0)]
    public XInternAtomReply Atom;
    [FieldOffset(0)]
    public XGetAtomNameReply AtomName;
    [FieldOffset(0)]
    public XGetPropertyReply Property;
    [FieldOffset(0)]
    public XListPropertiesReply ListProperties;
    [FieldOffset(0)]
    public XGetSelectionOwnerReply Selection;
    [FieldOffset(0)]
    public XGrabPointerReply GrabPointer;
    [FieldOffset(0)]
    public xGrabKeyboardReply GrabKeyboard;
    [FieldOffset(0)]
    public XQueryPointerReply Pointer;
    [FieldOffset(0)]
    public XGetMotionEventsReply MotionEvents;
    [FieldOffset(0)]
    public XTranslateCoordsReply Coords;
    [FieldOffset(0)]
    public XGetInputFocusReply InputFocus;
    [FieldOffset(0)]
    public XQueryTextExtentsReply TextExtents;
    [FieldOffset(0)]
    public XListFontsReply Fonts;
    [FieldOffset(0)]
    public XGetFontPathReply FontPath;
    [FieldOffset(0)]
    public xGetImageReply Image;
    [FieldOffset(0)]
    public xListInstalledColormapsReply Colormaps;
    [FieldOffset(0)]
    public xAllocColorReply AllocColor;
    [FieldOffset(0)]
    public xAllocNamedColorReply AllocNamedColor;
    [FieldOffset(0)]
    public xAllocColorCellsReply ColorCells;
    [FieldOffset(0)]
    public xAllocColorPlanesReply ColorPlanes;
    [FieldOffset(0)]
    public xQueryColorsReply Colors;
    [FieldOffset(0)]
    public xLookupColorReply LookupColor;
    [FieldOffset(0)]
    public xQueryBestSizeReply BestSize;
    [FieldOffset(0)]
    public xQueryExtensionReply Extension;
    [FieldOffset(0)]
    public xListExtensionsReply Extensions;
    [FieldOffset(0)]
    public xSetModifierMappingReply SetModifierMapping;
    [FieldOffset(0)]
    public xGetModifierMappingReply GetModifierMapping;
    [FieldOffset(0)]
    public xSetPointerMappingReply SetPointerMapping;
    [FieldOffset(0)]
    public xGetKeyboardMappingReply GetKeyboardMapping;
    [FieldOffset(0)]
    public xGetPointerMappingReply GetPointerMapping;
    [FieldOffset(0)]
    public xGetPointerControlReply PointerControl;
    [FieldOffset(0)]
    public xGetScreenSaverReply ScreenSaver;
    [FieldOffset(0)]
    public xListHostsReply Hosts;
    [FieldOffset(0)]
    public XError Error;
    [FieldOffset(0)]
    public XEvent Event;
}