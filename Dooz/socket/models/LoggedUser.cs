using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dooz.socket.models
{
    class LoggedUser
    {
        public long Id{ get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }

    }
}
