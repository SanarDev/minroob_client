using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dooz.socket.models
{
    class GamePlayer
    {
        [JsonProperty(propertyName: "id")]
        public long Id { set; get; }
        [JsonProperty(propertyName: "name")]
        public string Name { get; set; }
        [JsonProperty(propertyName: "score")]
        public string Score { get; set; }
    }
}
