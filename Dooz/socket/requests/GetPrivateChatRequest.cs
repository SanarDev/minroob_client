using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dooz.socket.requests
{
    class GetPrivateChatRequest
    {
        [JsonProperty(propertyName: "action")]
        public string Action { get; } = "get_private_chat_messages";
        [JsonProperty(propertyName: "player_id")]
        public long PlayerId { set; get; }
        [JsonProperty(propertyName: "from_message_id")]
        public long FromMessageId { set; get; } = -1;
    }
}
