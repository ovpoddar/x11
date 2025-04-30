using System.Runtime.InteropServices;

namespace X11cs.Models;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct XErrorEvent
{
    public Event Type;
    public Display* Display;   /* Display the event was read from */
    public ulong ResourceId;     /* resource id */
    public ulong Serial;   /* serial number of failed request */
    public byte ErrorCode;   /* error code of failed request */
    public byte RequestCode; /* Major op-code of failed request */
    public byte MinorCode;   /* Minor op-code of failed request */
}
