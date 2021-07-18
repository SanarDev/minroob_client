using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dooz.socket.models
{
    class GlobalMessage
    {
        public int Id { set; get; }
        public long PlayerId { set; get; }
        public string Fullname { set; get; }
        public string Message { set; get; }
        public long Timestamp { set; get; }
    }
}
