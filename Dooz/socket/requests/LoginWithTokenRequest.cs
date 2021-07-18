using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dooz.socket.requests
{
    class LoginWithTokenRequest
    {
        [JsonProperty(PropertyName = "action")]
        public string Action { get; } = "auth";

        [JsonProperty(PropertyName = "login_by")]
        public string LoginBy { get; } = "token";

        [JsonProperty(PropertyName = "token")]
        public string Token { get; set; }

        public LoginWithTokenRequest(string Token)
        {
            this.Token = Token;
        }
    }
}
