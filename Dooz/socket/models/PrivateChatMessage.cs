using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dooz.socket.models
{
    class PrivateChatMessage
    {
        [JsonProperty(propertyName:"id")]
        public long Id { get; set; }
        [JsonProperty(propertyName:"sender_player_id")]
        public long SenderPlayerId { get; set; }
        [JsonProperty(propertyName: "receiver_player_id")]
        public long ReceiverPlayerId { get; set; }
        [JsonProperty(propertyName: "message")]
        public string Message { get; set; }
        [JsonProperty(propertyName: "timestamp")]
        public long Timestamp { get; set; }

    }
}
