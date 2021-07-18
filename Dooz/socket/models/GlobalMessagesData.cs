using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dooz.socket.models
{
    class GlobalMessagesData
    {
        [JsonProperty(propertyName: "must_clear_history")]
        public bool MustClearHistory { get; set; }
        [JsonProperty(propertyName:"messages")]
        public List<GlobalMessage> Messages { get; set; }

    }
}
