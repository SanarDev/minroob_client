using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dooz.socket.requests
{
    class CancelGameRequest
    {
        [JsonProperty(propertyName: "action")]
        public string Action { get; } = "cancel_game_request";
        [JsonProperty(propertyName: "game_id")]
        public int GameId { get; set; }
    }
}
