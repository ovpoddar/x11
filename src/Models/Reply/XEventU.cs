using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace X11cs.Models.Reply;
[StructLayout(LayoutKind.Sequential)]
public struct XEventU
{
    public byte Type;
    public byte Detail;
    public ushort SequenceNumber;
}
