using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace X11cs.Models;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct TableEntry
{
    public ulong RId;
    public int Context;
    public IntPtr Data;
    public TableEntry* Next;
}
