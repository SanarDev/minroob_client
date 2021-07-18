using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dooz.socket.models
{
    class GameData
    {
        [JsonProperty(propertyName:"game_id")]
        public long GameId { set; get; }
        [JsonProperty(propertyName: "data")]
        public List<List<String>> Map { get; set; }
        [JsonProperty(propertyName:"turn")]
        public string Turn { get; set; }
        [JsonProperty(propertyName: "player_one")]
        public GamePlayer Player1 { set; get; }
        [JsonProperty(propertyName:"player_two")]
        public GamePlayer Player2 { get; set; }
    }
}
