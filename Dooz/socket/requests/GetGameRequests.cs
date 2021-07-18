using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dooz.socket.requests
{
    class GetGameRequests
    {
        [JsonProperty(propertyName: "action")]
        public string Action { get; } = "get_game_requests";
    }
}
