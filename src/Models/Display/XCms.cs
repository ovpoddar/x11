using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace X11cs.Models.Display;
[StructLayout(LayoutKind.Sequential)]
public struct XCms
{
    public nint DefaultCCCs;/* pointer to an array of default XcmsCCC */
    public nint ClientCmaps;/* pointer to linked list of XcmsCmapRec */
    public nint PerVisualIntensityMaps;/* linked list of XcmsIntensityMap */
}

