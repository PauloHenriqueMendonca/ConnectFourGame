using Newtonsoft.Json;

namespace ConnectFourGame.ViewModels
{
    public class UserVM
    {
        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("user")]
        public string Username { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("passwordConfirmation")]
        public string PasswordConfirmation { get; set; }

    }
}