using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FutBotDataBaseWebAPI.Models
{
    public class AnswerMona
    {
        [JsonProperty("url")]
        public string url { get; set; }
        [JsonProperty("FotoChromo")]
        public string FotoChromo { get; set; }
    }
}