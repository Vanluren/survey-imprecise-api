using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace survey_imprecise_api.Models
{
    public partial class Case
    {
        public int CaseId { get; set; }
        public virtual List<CaseParameter> Parameters { get; set; }

        [JsonIgnore]
        public virtual Supplier Supplier { get; set; }
    }
}
