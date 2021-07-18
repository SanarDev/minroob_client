using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dooz.socket.requests
{
    class AcceptGameRequest
    {
        [JsonProperty(propertyName: "action")]
        public string Action { get; } = "accept_game_request";
        [JsonProperty(propertyName: "game_id")]
        public long GameId { get; set; }
    }
}
