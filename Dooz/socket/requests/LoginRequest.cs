using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dooz.socket.requests
{
    class LoginRequest
    {
        [JsonProperty(PropertyName = "action")]
        public string Action { get; } = "auth";

        [JsonProperty(PropertyName = "username")]
        public string Username { get; set; }

        [JsonProperty(PropertyName = "login_by")]
        public string LoginBy { get; } = "user_pass";

        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }

        public LoginRequest(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;
        }
    }
}
