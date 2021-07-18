using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dooz.socket.models
{
    class ResumeGame
    {
        [JsonProperty(propertyName:"player_name")]
        public string PlayerName { get; set; }
        [JsonProperty(propertyName: "game_id")]
        public long GameId { set; get; }
    }
}
