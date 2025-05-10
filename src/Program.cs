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

if (!soc.Connected) return;
var xAuthority = Helper.GetAuthInfo();
using var connection = new NetworkStream(soc);
// handshake
using var writer = new BinaryWriter(connection);
writer.Write(BitConverter.IsLittleEndian ? 'l' : 'B'); // protocol
writer.Write((short)11); // major version
writer.Write((short)0); // minor version
writer.Write((short)xAuthority.authName.Length); // name length
writer.Write((short)xAuthority.authData.Length); // data length
writer.Write((short)0); // pad
writer.Write(xAuthority.authName); // name
while (xAuthority.authName.Length % 4 != 0) writer.Write((byte)0); // pad
writer.Write(xAuthority.authData); // data
while (xAuthority.authData.Length % 4 != 0) writer.Write((byte)0); // pad

byte[] c = new byte[1024];

var read = connection.Read(c, 0, c.Length);
Console.WriteLine(string.Join(",", c.Take(read)));

/*
// createwindow
writer.Write((byte)1); // opcode
writer.Write((byte)0); // depth
writer.Write((short)9); // size

writer.Write((int)0); // window
writer.Write((int)0); // parent

writer.Write((short)0); // x
writer.Write((short)0); // y
writer.Write((short)500); // width
writer.Write((short)500); // height
writer.Write((short)0); // border width

writer.Write((short)0); // class
writer.Write((int)0); // visual

writer.Write((int)32832); // value mask
*/