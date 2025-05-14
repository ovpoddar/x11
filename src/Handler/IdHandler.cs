using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using src.Model.Handshake;

namespace src.Handler
{
    public static class IdHandler
    {
        private static int _globalId = 0;
        public static int GetId(HandshakeResponseSuccessBody handshakeResponseSuccess)
        {
            var result = (int)((handshakeResponseSuccess.ResourceIDMask & _globalId) | handshakeResponseSuccess.ResourceIDBase);
            _globalId += 1;
            return result;
        }
    }
}