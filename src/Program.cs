using System.IO;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using src.Handler;
using src.Model;
using X11cs;


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

var shift = 0;
var x = 0;
while (((result.HandshakeResponseSuccessBody.ResourceIDMask >> shift) & 1) != 0)
    shift++;

var window = result.HandshakeResponseSuccessBody.ResourceIDBase + (x << shift);


// create window
Span<byte> createWindowRequest = stackalloc byte[32];
var writeIndex = 0;
createWindowRequest[writeIndex++] = 1;
createWindowRequest[writeIndex++] = result.Screen[0].RootDepth;
MemoryMarshal.Write<ushort>(createWindowRequest[writeIndex..], 8 + 1); // 8 + 
writeIndex += 2;
MemoryMarshal.Write<uint>(createWindowRequest[writeIndex..], (uint)window);// do something else
writeIndex += 4;
MemoryMarshal.Write<uint>(createWindowRequest[writeIndex..], result.Screen[0].Root);
writeIndex += 4;
MemoryMarshal.Write<ushort>(createWindowRequest[writeIndex..], 0); // x
writeIndex += 2;
MemoryMarshal.Write<ushort>(createWindowRequest[writeIndex..], 0); // y
writeIndex += 2;
MemoryMarshal.Write<ushort>(createWindowRequest[writeIndex..], 500); //width
writeIndex += 2;
MemoryMarshal.Write<ushort>(createWindowRequest[writeIndex..], 500); //height
writeIndex += 2;
MemoryMarshal.Write<ushort>(createWindowRequest[writeIndex..], 0); // border width
writeIndex += 2;
MemoryMarshal.Write<ushort>(createWindowRequest[writeIndex..], 0); // class
writeIndex += 2;
MemoryMarshal.Write<uint>(createWindowRequest[writeIndex..], result.Screen[0].RootVisualId); // visual id
writeIndex += 4;
MemoryMarshal.Write<int>(createWindowRequest[writeIndex..], (int)ValueMask.EventMask); // value-mask
writeIndex += 4;
MemoryMarshal.Write<int>(createWindowRequest[writeIndex..], (int)(EventMask.PointerMotionMask | EventMask.ExposureMask)); // value-mask
writeIndex += 4;
soc.Send(createWindowRequest);

Console.WriteLine();