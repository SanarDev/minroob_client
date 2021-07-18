using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dooz.socket.requests
{
    class CreateAccountRequest
    {
        [JsonProperty(propertyName:"action")]
        public string Action { get; } = "create_account";
        [JsonProperty(propertyName:"username")]
        public string Username { get; set; }
        [JsonProperty(propertyName:"fullname")]
        public string Fullname { get; set; }
        [JsonProperty(propertyName: "password")]
        public string Password { get; set; }
        [JsonProperty(propertyName: "password2")]
        public string Password2 { get; set; }
    }
}
