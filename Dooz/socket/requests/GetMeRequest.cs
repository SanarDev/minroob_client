using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dooz.socket.requests
{
    class GetMeRequest
    {
        [JsonProperty(propertyName: "action")]
        public string Action { get; } = "get_me";
    }
}
