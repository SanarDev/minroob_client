using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dooz.socket.models
{
    class InComingGameRequest
    {
        public string Fullname { get; set; }
        public string Username { get; set; }
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public long Timestamp { get; set; }
    }
}
