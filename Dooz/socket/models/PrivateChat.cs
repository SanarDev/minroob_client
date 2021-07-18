using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dooz.socket.models
{
    class PrivateChat
    {
        [JsonProperty(propertyName:"chat_with")]
        public long ChatWith { get; set; }
        [JsonProperty(propertyName: "messages")]
        public List<PrivateChatMessage> Messages { get; set; }
        [JsonProperty(propertyName: "must_clear_history")]
        public bool MustClearHistory { get; set; }

    }
}
