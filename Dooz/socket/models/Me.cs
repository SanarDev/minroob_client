using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dooz.socket.models
{
    class Me
    {
        [JsonProperty(propertyName:"total_games")]
        public int TotalGames { get; set; }
        [JsonProperty(propertyName: "wins")]
        public int Wins { get; set; }
        [JsonProperty(propertyName: "fullname")]
        public string Fullname { get; set; }
        [JsonProperty(propertyName: "username")]
        public string Username { get; set; }
    }
}
