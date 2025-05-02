﻿using System.Runtime.InteropServices;

namespace X11cs.Models.Display;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct _XLockInfo
{
    public nint Mutex;     /* mutex for critical sections */
    public int ReplyBytesLeft;   /* nbytes of the reply still to read */
    public bool ReplyWasRead;    /* _XReadEvents read a reply for _XReply */
    public _XCVList* ReplyAwaiters; /* list of CVs for _XReply */
    public nint ReplyAwaitersTail;
    public _XCVList* EventAwaiters; /* list of CVs for _XReadEvents */
    public nint EventAwaitersTail;
    public bool reply_first;   /* who may read, reply queue or event queue */
    /* for XLockDisplay */
    public int LockingLevel;  /* how many times into XLockDisplay we are */
    public ulong LockingThread; /* thread that did XLockDisplay */
    public nint Cv;    /* wait if another thread has XLockDisplay */
    public ulong ReadingThread; /* cache */
    public ulong ConnectionThread; /* thread in XProcessInternalConnection */
    public nint Writers;   /* wait for writable */
    public int NumberFreeCVls;
    public _XCVList* FreeCVls;
    /* used only in XlibInt.c */
    public delegate* unmanaged[Cdecl]<XDisplay*, _XCVList**, _XCVList***, void> PopReader;
    public delegate* unmanaged[Cdecl]<XDisplay*, _XCVList***, _XCVList*> PushReader;
    public delegate* unmanaged[Cdecl]<nint, nint, nint, int, void> ConditionWait;
    public delegate* unmanaged[Cdecl]<XDisplay*, bool, nint, int, void> InternalLockDisplay;
    /* used in XlibInt.c and locking.c */
    public delegate* unmanaged[Cdecl]<nint, nint, int, void> ConditionSignal;
    public delegate* unmanaged[Cdecl]<nint, nint, int, void> ConditionBroadcast;
    /* used in XlibInt.c and XLockDis.c */
    public delegate* unmanaged[Cdecl]<XDisplay*, void> LockWait;
    public delegate* unmanaged[Cdecl]<XDisplay*, void> UserLockDisplay;
    public delegate* unmanaged[Cdecl]<XDisplay*, void> UserUnlockDisplay;
    public delegate* unmanaged[Cdecl]<XDisplay*, _XCVList*> CreateCvl;

}