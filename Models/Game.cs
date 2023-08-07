using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConnectFourGame.Models
{
    public class Game
    {
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("gameId")]
        public int GameId { get; set; }
        
        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("winner")]
        public string Winner { get; set; }

        [JsonProperty("quantMoves")]
        public string QuantMoves { get; set; }
    }
}