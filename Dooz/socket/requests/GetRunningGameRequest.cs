using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dooz.socket.requests
{
    class GetRunningGameRequest
    {
        [JsonProperty(propertyName:"action")]
        public string Action { get; } = "get_running_game";
    }
}
