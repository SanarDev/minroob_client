using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dooz.socket.requests
{
    class CancelWaitingForPlayerRequest
    {
        [JsonProperty(propertyName:"action")]
        public string Action { get; } = "cancel_waiting_for_player";
        [JsonProperty(propertyName: "game_id")]
        public long GameId { set; get; }
    }
}
