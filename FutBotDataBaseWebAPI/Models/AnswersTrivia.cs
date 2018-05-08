using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FutBotDataBaseWebAPI.Models
{
    public class AnswersTrivia
    {
        [JsonProperty("Answer")]
        public string Answer { get; set; }
        [JsonProperty("Flag")]
        public int? Flag { get; set; }
    }
}