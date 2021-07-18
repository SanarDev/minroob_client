using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dooz.socket.requests
{
    class AnnouncementOfLossGameRequest
    {
        [JsonProperty(propertyName: "action")]
        public string Action { get; } = "announcement_of_loss_game";
        [JsonProperty(propertyName: "game_id")]
        public long GameId { set; get; }
    }
}
