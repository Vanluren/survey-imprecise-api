using System;
using System.Collections.Generic;

namespace survey_imprecise_api.Models
{
    public partial class Case
    {
        public int CaseId { get; set; }
        public List<CaseParameter> Parameters { get; set; }

        public Supplier Supplier { get; set; }
    }
}
