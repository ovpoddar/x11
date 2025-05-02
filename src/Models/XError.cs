using System.Runtime.InteropServices;

namespace X11cs.Models;

/*
public struct _xEvent
{
    union
    {
        struct
        {
        public byte type;
        public byte detail;
        public ushort sequenceNumber;
    }
    u;
        struct
        {
        public uint pad00;
        public uint time;
        public uint root, event, child;
            short rootX, rootY, eventX, eventY;
        public ushort state;
        public byte sameScreen;
        public byte pad1;
    }
    keyButtonPointer;
        struct
        {
        public uint pad00;
        public uint time;
        public uint root, event, child;
            short rootX, rootY, eventX, eventY;
        public ushort state;
        public byte mode;  // really XMode 
        public byte flags; // sameScreen and focus booleans, packed together 
#define ELFlagFocus (1 << 0)
#define ELFlagSameScreen (1 << 1)
    }
    enterLeave;
        struct
        {
        public uint pad00;
        public uint window;
        public byte mode; // really XMode 
public byte pad1, pad2, pad3;
    }
    focus;
        struct
        {
        public uint pad00;
        public uint window;
        public ushort x, y, width, height;
        public ushort count;
        public ushort pad2;
    }
    expose;
        struct
        {
        public uint pad00;
        public uint drawable;
        public ushort x, y, width, height;
        public ushort minorEvent;
        public ushort count;
        public byte majorEvent;
        public byte pad1, pad2, pad3;
    }
    graphicsExposure;
        struct
        {
        public uint pad00;
        public uint drawable;
        public ushort minorEvent;
        public byte majorEvent;
        public byte bpad;
    }
    noExposure;
        struct
        {
        public uint pad00;
        public uint window;
        public byte state;
        public byte pad1, pad2, pad3;
    }
    visibility;
        struct
        {
        public uint pad00;
        public uint parent, window;
        short x, y;
        public ushort width, height, borderWidth;
        public byte override;
            public byte bpad;
    }
    createNotify;
        
         //* The event fields in the structures for DestroyNotify, UnmapNotify,
         //* MapNotify, ReparentNotify, ConfigureNotify, CirculateNotify, GravityNotify,
         //* must be at the same offset because server internal code is depending upon
         //* this to patch up the events before they are delivered.
         //* Also note that MapRequest, ConfigureRequest and CirculateRequest have
         //* the same offset for the event window.
         
struct
        {
        public uint pad00;
        public uint event, window;
        }
        destroyNotify;
        struct
        {
            public uint pad00;
            public uint event, window;
            public byte fromConfigure;
            public byte pad1, pad2, pad3;
        }
        unmapNotify;
        struct
        {
            public uint pad00;
            public uint event, window;
            public byte override;
            public byte pad1, pad2, pad3;
        }
        mapNotify;
        struct
        {
            public uint pad00;
            public uint parent, window;
        }
        mapRequest;
        struct
        {
            public uint pad00;
            public uint event, window, parent;
            short x, y;
            public byte override;
            public byte pad1, pad2, pad3;
        }
        reparent;
        struct
        {
            public uint pad00;
            public uint event, window, aboveSibling;
            short x, y;
            public ushort width, height, borderWidth;
            public byte override;
            public byte bpad;
        }
        configureNotify;
        struct
        {
            public uint pad00;
            public uint parent, window, sibling;
            short x, y;
            public ushort width, height, borderWidth;
            public ushort valueMask;
            public uint pad1;
        }
        configureRequest;
        struct
        {
            public uint pad00;
            public uint event, window;
            short x, y;
            public uint pad1, pad2, pad3, pad4;
        }
        gravity;
        struct
        {
            public uint pad00;
            public uint window;
            public ushort width, height;
        }
        resizeRequest;
        struct
        {
        //The event field in the circulate record is really the parent when this
        //       is used as a CirculateRequest instead of a CirculateNotify
            public uint pad00;
            public uint event, window, parent;
            public byte place; // Top or Bottom
            public byte pad1, pad2, pad3;
        }
        circulate;
        struct
        {
            public uint pad00;
            public uint window;
            public uint atom;
            public uint time;
            public byte state; // NewValue or Deleted
            public byte pad1;
            public ushort pad2;
        }
        property;
        struct
        {
            public uint pad00;
            public uint time;
            public uint window;
            public uint atom;
        }
        selectionClear;
        struct
        {
            public uint pad00;
            public uint time;
            public uint owner, requestor;
            public uint selection, target, property;
        }
        selectionRequest;
        struct
        {
            public uint pad00;
            public uint time;
            public uint requestor;
            public uint selection, target, property;
        }
        selectionNotify;
        struct
        {
            public uint pad00;
            public uint window;
            public uint colormap;
#if defined(__cplusplus) || defined(c_plusplus)
            public byte c_new;
#else
            public byte new;
#endif
            public byte state; // Installed or UnInstalled
            public byte pad1, pad2;
        }
        colormap;
        struct
        {
            public uint pad00;
            public byte request;
            public byte firstKeyCode;
            public byte count;
            public byte pad1;
        }
        mappingNotify;
        struct
        {
            public uint pad00;
            public uint window;
            union
            {
                struct
                {
                public uint type;
                public int longs0;
                public int longs1;
                public int longs2;
                public int longs3;
                public int longs4;
            }
            l;
                struct
                {
                public uint type;
                short shorts0;
                short shorts1;
                short shorts2;
                short shorts3;
                short shorts4;
                short shorts5;
                short shorts6;
                short shorts7;
                short shorts8;
                short shorts9;
            }
            s;
                struct
                {
                public uint type;
                signed char bytes[20];
            }
            b;
            }
        u;
        }
    clientMessage;
    }
u;
}
*/
[StructLayout(LayoutKind.Sequential)]
public struct XError
{
    public byte Type; /* X_Error */
    public byte ErrorCode;
    public ushort SequenceNumber; /* the nth request from this client */
    public uint ResourceID;
    public ushort MinorCode;
    public byte MajorCode;
    public byte Pad1;
    public uint Pad3;
    public uint Pad4;
    public uint Pad5;
    public uint Pad6;
    public uint Pad7;
}
