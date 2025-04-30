using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace X11cs.Models;
public unsafe struct XExtData
{
    public int Number;
    public XExtData* Next;  /* next item on list of data for structure */
    public delegate* unmanaged[Cdecl]<XExtData*, int> FreePrivate; /* function to free private data */
	public IntPtr PrivateData;	/* data private to this extension. */
}
