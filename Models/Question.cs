using System.Collections.Generic;

namespace survey_imprecise_api.Models
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string Content { get; set; }
        public virtual List<QuestionCases> QuestionCases { get; set; }
    }
}