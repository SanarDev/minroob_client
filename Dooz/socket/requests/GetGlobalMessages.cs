using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dooz.socket.requests
{
    class GetGlobalMessages
    {
        [JsonProperty(propertyName:"action")]
        public string Action { get; } = "get_global_messages";
        [JsonProperty(propertyName: "from_message_id")]
        public long FromMessageId { get; set; } = -1;
    }
}
