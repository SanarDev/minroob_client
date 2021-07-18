using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dooz.socket.errors
{
    class ErrorSignUp
    {
        [JsonProperty(propertyName:"message")]
        public string Message { get; set; }

    }
}
