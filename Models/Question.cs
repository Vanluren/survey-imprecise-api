using System.Collections.Generic;
using Newtonsoft.Json;

namespace survey_imprecise_api.Models
{
    public class Question
    {
        public Question()
        {
            QuestionCases = new HashSet<QuestionCases>();
        }

        public int QuestionId { get; set; }
        public string Content { get; set; }

        public virtual ICollection<QuestionCases> QuestionCases { get; set; }
    }
}