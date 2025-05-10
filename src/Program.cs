using System.IO;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using src.Handler;
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
if (socket.Length != 0)  connectionSocket = display;
else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) connectionSocket = $"{host}:{6000 + displayNumber}";
else connectionSocket = $"/tmp/.X11-unix/X{displayNumber}";

var soc = new Socket(AddressFamily.Unix, SocketType.Stream, protocol);
soc.Connect(new UnixDomainSocketEndPoint(connectionSocket));
if (!soc.Connected) return;

using var connection = new NetworkStream(soc);
HandshakeHandler.MakeHandshake(connection);