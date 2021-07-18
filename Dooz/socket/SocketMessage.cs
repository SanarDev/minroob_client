using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dooz.socket
{
    class SocketMessage
    {
        public string Status { get; set; }
        public string Type { get; set; } // success
        public string Message { get; set; } // fail
        public int Code { get; set; } // fail
        public string Data { get; set; }
    }
}
