using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace survey_imprecise_api.Models
{
    public partial class Case
    {
        public Case()
        {
            CaseParameters = new HashSet<CaseParameter>();
            QuestionCases = new HashSet<QuestionCases>();
            Responses = new HashSet<Response>();
        }

        public int CaseId { get; set; }

        public virtual ICollection<CaseParameter> CaseParameters { get; set; }
        [JsonIgnore]
        public virtual ICollection<QuestionCases> QuestionCases { get; set; }
        [JsonIgnore]
        public virtual ICollection<Response> Responses { get; set; }
    }
}
