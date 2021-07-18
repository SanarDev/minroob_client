using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dooz.socket.requests
{
    class AddMessageInPrivateChatRequest
    {
        [JsonProperty(propertyName: "action")]
        public string Action { get; } = "add_message_in_private_chat";
        [JsonProperty(propertyName: "player_id")]
        public long PlayerId { get; set; }
        [JsonProperty(propertyName: "message")]
        public string Message { get; set; }
    }
}
