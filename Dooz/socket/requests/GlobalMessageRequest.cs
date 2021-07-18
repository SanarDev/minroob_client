using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dooz.socket.requests
{
    class GlobalMessageRequest
    {
        [JsonProperty(PropertyName = "action")]
        public string Action { get; } = "global_message";

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }
    }
}
