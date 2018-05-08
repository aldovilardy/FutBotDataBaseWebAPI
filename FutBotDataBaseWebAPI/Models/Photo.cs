using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FutBotDataBaseWebAPI.Models
{
    public class Photo
    {
        [JsonProperty("contentType")]
        public string ContentType { get; set; }
        [JsonProperty("contentUrl")]
        public string ContentUrl { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}