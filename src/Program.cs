using System.Buffers;
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

var window = IdHandler.GetId(result.HandshakeResponseSuccessBody);


// create window
var createWindowRequest = new List<byte>
{
    1,                                                          // opcode
    result.Screen[0].RootDepth,                                 // depth
    8+1,                                                        // request length
    0,
};
createWindowRequest.AddRange(BitConverter.GetBytes(window));    // window
createWindowRequest.AddRange(BitConverter.GetBytes(result.Screen[0].Root)); // parent
createWindowRequest.AddRange([0, 0]); // x
createWindowRequest.AddRange([0, 0]); // y
createWindowRequest.AddRange([244, 1]); // width
createWindowRequest.AddRange([244, 1]); // height
createWindowRequest.AddRange([1, 0]); // border width
createWindowRequest.AddRange([0, 0]); // class
createWindowRequest.AddRange(BitConverter.GetBytes(result.Screen[0].RootVisualId)); // class
createWindowRequest.AddRange(BitConverter.GetBytes((int)(ValueMask.WinGravity | ValueMask.BackgroundPixel))); // value-mask
createWindowRequest.AddRange(BitConverter.GetBytes(0xff000000)); // value-mask
createWindowRequest.AddRange(BitConverter.GetBytes((int)(EventMask.ExposureMask | EventMask.KeyPressMask))); // value-mask
soc.Send(createWindowRequest.ToArray());

// map window
Span<byte> mapWindow = stackalloc byte[8];
mapWindow[0] = 9;
MemoryMarshal.Write<ushort>(mapWindow[2..], 2);
MemoryMarshal.Write<int>(mapWindow[4..], window);
soc.Send(mapWindow);

var isRunning = true;

while (isRunning)
{
    var rent = ArrayPool<byte>.Shared.Rent(1024 * 2); // should not be more than event size assuming.

    var totalRead = await soc.ReceiveAsync(rent);
    Console.WriteLine($"received event. {totalRead}");
    if (rent[0] == 0)
    {
        System.Console.WriteLine();
    }
    else if (rent[0] == 1)
    {
        System.Console.WriteLine("got reply");
    }
    else
    {
        System.Console.WriteLine($"event {rent[0]}");
    }
    ArrayPool<byte>.Shared.Return(rent);

}
Console.WriteLine();