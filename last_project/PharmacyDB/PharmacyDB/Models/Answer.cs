using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PharmacyDB.Models
{
    public partial class Answer
    {
        [JsonIgnore]
        public int Id { get; set; }
        public int UserQuestionsId { get; set; }
        public int? ChoiceId { get; set; }
        public string? AnswerText { get; set; }
        [JsonIgnore]
        public virtual Choice? Choice { get; set; }
        [JsonIgnore]
        public virtual UserQuestion UserQuestionIsdNavigation { get; set; } = null!;
    }
}
