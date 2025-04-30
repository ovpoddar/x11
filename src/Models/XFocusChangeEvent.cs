using System.Runtime.InteropServices;

namespace X11cs.Models;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct XFocusChangeEvent
{
    public Event Type;       /* FocusIn or FocusOut */
    public ulong Serial;   /* # of last request processed by server */
    public int SendEvent;    /* true if this came from a SendEvent request */
    public Display* Display;   /* Display the event was read from */
    public ulong Window;      /* window of event */
    public int Mode;       /* NotifyNormal, NotifyWhileGrabbed,
				   NotifyGrab, NotifyUngrab */
    public int Detail;
    /*
	 * NotifyAncestor, NotifyVirtual, NotifyInferior,
	 * NotifyNonlinear,NotifyNonlinearVirtual, NotifyPointer,
	 * NotifyPointerRoot, NotifyDetailNone
	 */
}



