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
        socket = [];
        host = [];
        displayNumber = 0;
        screenNumber = 0;
        protocol = ProtocolType.IP;
        
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
                if (!Enum.TryParse<ProtocolType>(display[0..slashIndex].ToString(), true, out protocol))
                    protocol = ProtocolType.Tcp;

                host = display[(slashIndex + 1)..colonIndex];
            }
            else
            {
                host = display[0..colonIndex];
            }
        }

        var displayNumberStart = display[colonIndex..];
        if (displayNumberStart.Length == 0)
            return false;
        
        var dotIndex = displayNumberStart.IndexOf('.');
        if (dotIndex < 0)
        {
            return int.TryParse(displayNumberStart[(dotIndex + 1)..], out displayNumber);
        }
        else
        {
            if (!int.TryParse(displayNumberStart[1..dotIndex], out displayNumber))
                return false;

            return int.TryParse(displayNumberStart[(dotIndex + 1)..], out screenNumber);
        }
    }
}
