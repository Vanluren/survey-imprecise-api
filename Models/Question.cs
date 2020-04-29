using System.Collections.Generic;
using Newtonsoft.Json;

namespace survey_imprecise_api.Models
{
    public class Question
    {
        public virtual int QuestionId { get; set; }
        public virtual string Content { get; set; }

        public virtual List<QuestionCases> Cases { get; set; }
    }
}