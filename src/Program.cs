using System;
using System.Buffers;
using System.Buffers.Binary;
using System.IO;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using src.Handler;
using src.Model;
using X11cs;
using X11cs.Model;


var display = Environment.GetEnvironmentVariable("DISPLAY") ?? ":0";
if (Helper.TryParseDisplayConfiguration(display,
    out var socket,
    out var host,
    out var displayNumber,
    out var screenNumber,
    out var protocol))
{
    return;
}
string connectionSocket;
if (socket.Length != 0) connectionSocket = display;
else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) connectionSocket = $"{host}:{6000 + displayNumber}";
else connectionSocket = $"/tmp/.X11-unix/X{displayNumber}";

var soc = new Socket(AddressFamily.Unix, SocketType.Stream, protocol);
soc.Connect(new UnixDomainSocketEndPoint(connectionSocket));
if (!soc.Connected) return;

// handshake done
var result = HandshakeHandler.MakeHandshake(soc);

var window = IdHandler.GetId(result.HandshakeResponseSuccessBody);

if (result.Screen == null || result.Screen.Length == 0)
    return;

// create window
Span<byte> createWindowRequest = stackalloc byte[40];
createWindowRequest[0] = 1;
createWindowRequest[1] = 0;
MemoryMarshal.Write<ushort>(createWindowRequest[2..4], 10);
MemoryMarshal.Write(createWindowRequest[4..8], window);
MemoryMarshal.Write(createWindowRequest[8..12], result.Screen[0].Root);
MemoryMarshal.Write(createWindowRequest[12..14], (short)0);                // x
MemoryMarshal.Write(createWindowRequest[14..16], (short)0);                // y
MemoryMarshal.Write(createWindowRequest[16..18], (ushort)500);             // width
MemoryMarshal.Write(createWindowRequest[18..20], (ushort)500);             // height
// 20..22               // border width
MemoryMarshal.Write(createWindowRequest[22..24], (ushort)1);               // class: InputOutput
MemoryMarshal.Write(createWindowRequest[24..28], result.Screen[0].RootVisualId);     // visual
MemoryMarshal.Write(createWindowRequest[28..32], (uint)(ValueMask.BackgroundPixel | ValueMask.EventMask));
MemoryMarshal.Write(createWindowRequest[32..36], 0xff000000); // BackgroundPixel (e.g., white)
MemoryMarshal.Write(createWindowRequest[36..40], (uint)(EventMask.ExposureMask | EventMask.KeyPressMask));
soc.Send(createWindowRequest);

// map window
Span<byte> mapWindow = stackalloc byte[8];
mapWindow[0] = 8;
MemoryMarshal.Write<ushort>(mapWindow[2..], 2);
MemoryMarshal.Write<int>(mapWindow[4..], window);
soc.Send(mapWindow);

var isRunning = true;
while (isRunning)
{
    var rent = ArrayPool<byte>.Shared.Rent(1024 * 2); // should not be more than event size assuming.
    if (soc.Poll(-1, SelectMode.SelectRead))
    {
        var totalRead = soc.Receive(rent);
        if (rent[0] == 0 || rent[0] == 1 || totalRead == 0)
        {
            Console.WriteLine("Some thing gone wrong check the code.");
            if (soc.Connected)
                soc.Disconnect(true);
            isRunning = false;
        }
        else
        {
            Console.WriteLine($"received event. {totalRead}");
            var evnt = (Event)rent[0];
            Console.WriteLine($"event {evnt}");
        }
    }
    ArrayPool<byte>.Shared.Return(rent);
}
Console.WriteLine();