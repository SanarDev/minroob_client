using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dooz.socket.requests
{
    class GetGameDataRequest
    {
        [JsonProperty(propertyName: "action")]
        public string Action { get; } = "get_game_data";
        [JsonProperty(propertyName: "game_id")]
        public long GameId { set; get; }
    }
}
