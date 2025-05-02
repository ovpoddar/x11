﻿using System.Runtime.InteropServices;

namespace X11cs.Models;

public unsafe struct XEvent
{
    public Event Type;
    public XAnyEvent XAny;
    public XKeyEvent XKey;
    public XButtonEvent XButton;
    public XMotionEvent XMotion;
    public XCrossingEvent XCrossing;
    public XFocusChangeEvent XFocus;
    public XExposeEvent XExpose;
    public XGraphicsExposeEvent XGraphicsExpose;
    public XNoExposeEvent XNoExpose;
    public XVisibilityEvent XVisibility;
    public XCreateWindowEvent XCreateWindow; //72
    public XDestroyWindowEvent XDestroyWindow; //48
    public XUnMapEvent XUnMap; //56
    public XMapEvent XMap; //56
    public XMapRequestEvent XMapRequest; //48
    public XReParentEvent XReParent; //72
    public XConfigureEvent XConfigure; //88
    public XGravityEvent XGravity; //56
    public XResizeRequestEvent XResizeRequest; //48
    public XConfigureRequestEvent XConfigureRequest; //96
    public XCirculateEvent XCirculate;// 56
    public XCirculateRequestEvent XCirculateRequest; //56
    public XPropertyEvent XProperty; //64
    public XSelectionClearEvent XSelectionClear; //56
    public XSelectionRequestEvent XSelectionRequest; //80
    public XSelectionEvent XSelection; // 72
    public XColorMapEvent XColorMap; //56
    public XClientMessageEvent XClient; //96
    public XMappingEvent XMapping; //56
    public XErrorEvent XError; //40
    public XKeyMapEvent XKeyMap; //72
    public XGenericEvent XGeneric; //40
    public XGenericEventCookie XCookie; //56

    private XEvent(ref IntPtr pointer)
    {
        this.XAny = Marshal.PtrToStructure<XAnyEvent>(pointer);
        this.Type = this.XAny.Type;
        switch (this.Type)
        {
            case Event.Expose:
                XExpose = Marshal.PtrToStructure<XExposeEvent>(pointer);
                break;
            case Event.ClientMessage:
                XClient = Marshal.PtrToStructure<XClientMessageEvent>(pointer);
                break;
            case Event.ButtonPress:
            case Event.ButtonRelease:
                XButton = Marshal.PtrToStructure<XButtonEvent>(pointer);
                break;
            case Event.ReParentNotify:
                XReParent = Marshal.PtrToStructure<XReParentEvent>(pointer);
                break;
            case Event.UnMapNotify:
                XUnMap = Marshal.PtrToStructure<XUnMapEvent>(pointer);
                break;
            default:
                throw new NotImplementedException();
        }
    }

    public static implicit operator XEvent(_XEvent _XEvent)
    {
        var pointer = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(_XEvent)));
        try
        {
            Marshal.StructureToPtr(_XEvent, pointer, false);
            return new XEvent(ref pointer);
        }
        finally
        {
            Marshal.FreeHGlobal(pointer);
        }
    }
}