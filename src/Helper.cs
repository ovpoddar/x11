using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace X11cs;
internal static class Helper
{
    public static bool TryParseDisplayConfiguration(ReadOnlySpan<char> display,
        out ReadOnlySpan<char> socket,
        out ReadOnlySpan<char> host,
        out int displayNumber,
        out int screenNumber,
        out ProtocolType protocol)
    {
        socket = ReadOnlySpan<char>.Empty;
        host = ReadOnlySpan<char>.Empty;
        displayNumber = 0;
        screenNumber = 0;
        protocol = ProtocolType.Tcp;

        if (display.Length == 0)
            return false;

        var colonIndex = display.LastIndexOf(':');
        if (colonIndex == -1)
            return false;

        if (display[0] == '/')
            socket = display[0..colonIndex];
        else
        {
            var slashIndex = display.IndexOf('/');
            if (slashIndex >= 0)
            {
                Enum.Parse<ProtocolType>(display[0..slashIndex].ToString(), true);
                host = display[(slashIndex + 1)..colonIndex];
            }
            else
            {
                host = display[0..colonIndex];
            }
        }

        var displayNumberStart = display[(colonIndex + 1)..];
        if (displayNumberStart.Length == 0)
            return false;

        var dotIndex = displayNumberStart.IndexOf('.');
        if (dotIndex < 0)
        {
            return int.TryParse(displayNumberStart[(dotIndex + 1)..], out displayNumber);
        }
        else
        {
            if (!int.TryParse(displayNumberStart.Slice(0, dotIndex), out displayNumber))
                return false;

            return int.TryParse(displayNumberStart.Slice(dotIndex + 1), out screenNumber);
        }
    }
}
