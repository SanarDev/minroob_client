using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dooz.socket.requests
{
    class GetOnlinePlayersRequest
    {
        [JsonProperty(PropertyName = "action")]
        public string Action { get; } = "get_online_players";
    }
}
