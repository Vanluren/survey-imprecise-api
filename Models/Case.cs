using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace survey_imprecise_api.Models
{
    public partial class Case
    {
        public virtual int CaseId { get; set; }
        public virtual List<CaseParameter> Parameters { get; set; }

        [JsonIgnore]
        public virtual Supplier Supplier { get; set; }

        [JsonIgnore]
        public virtual List<QuestionCases> Questions { get; set; }
    }
}
