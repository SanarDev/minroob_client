using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dooz.socket.models
{
    class PlayerStatus {
        public Player Player { get; set; }
        [JsonProperty(PropertyName = "is_online")]
        public bool IsOnline { set; get; }
    }
}
