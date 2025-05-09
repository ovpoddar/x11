using System.Net.Sockets;
using System.Runtime.InteropServices;
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

var soc = new Socket(AddressFamily.Unix, SocketType.Stream, protocol);

if (socket.Length != 0)
{
    soc.Connect(new UnixDomainSocketEndPoint(display));
}
else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
{
    soc.Connect(new UnixDomainSocketEndPoint($"{host}:{6000 + displayNumber}"));
}
else
{
    soc.Connect(new UnixDomainSocketEndPoint($"/tmp/.X11-unix/X{displayNumber}"));
}

if (!soc.Connected)
    return;