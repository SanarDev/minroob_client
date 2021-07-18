using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dooz.socket.models
{
    class GameEnd
    {
        [JsonProperty(propertyName:"action")]
        public string Action { get; }
        [JsonProperty(propertyName: "message")]
        public string Message { set; get; }
        [JsonProperty(propertyName: "is_winner")]
        public bool IsWinner { get; set; }
    }
}
