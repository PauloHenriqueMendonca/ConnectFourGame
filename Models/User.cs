using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConnectFourGame.Models
{
    public class User
    {
        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("user")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
        [JsonProperty("passwordConfirmation")]
        public string PasswordConfirmation { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}