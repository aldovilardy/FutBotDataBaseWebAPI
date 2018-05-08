using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FutBotDataBaseWebAPI.Models
{
    public class QuestionsTrivia
    {
        [JsonProperty("QuestionByStickerId")]
        public int QuestionByStickerId { get; set; }
        [JsonProperty("QuestionId")]
        public Nullable<int> QuestionId { get; set; }
        //public Nullable<int> IdEtiqueta { get; set; }
        [JsonProperty("Statement")]
        public string Statement { get; set; }
        [JsonProperty("Answers")]
        public List <AnswersTrivia> Answers { get; set; }
    }
}