using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dooz.socket.requests
{
    class GameRequest
    {
        [JsonProperty(propertyName:"action")]
        public string Action { get; } = "game_request";
        [JsonProperty(propertyName: "player_id")]
        public long PlayerId { get; set; }

    }
}
