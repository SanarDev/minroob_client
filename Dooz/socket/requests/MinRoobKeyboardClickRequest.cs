using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dooz.socket.requests
{
    class MinRoobKeyboardClickRequest
    {
        [JsonProperty(propertyName: "action")]
        public string Action { get; } = "minroob_click_action";
        [JsonProperty(propertyName: "game_id")]
        public long GameId { get; set; }
        [JsonProperty(propertyName: "col")]
        public int Col { get; set; }
        [JsonProperty(propertyName: "row")]
        public int Row { get; set; }
    }
}
