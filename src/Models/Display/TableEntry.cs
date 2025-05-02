using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace X11cs.Models.Display;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct TableEntry
{
    public ulong RId;
    public int Context;
    public nint Data;
    public TableEntry* Next;
}
