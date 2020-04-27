using System;
using System.Collections.Generic;

namespace survey_imprecise_api.Models
{
    public partial class Supplier
    {
        public int SupplierId { get; set; }
        public string Name {get; set;}
        public int Soil { get; set; }
        public int Husbandry { get; set; }
        public int Nutrients { get; set; }
        public int Water { get; set; }
        public int Energy { get; set; }
        public int Biodiversity { get; set; }
        public int Workconditions { get; set; }
        public int Lifeequality { get; set; }
        public int Economy { get; set; }
        public int Management { get; set; }

        public List<Case> Cases {get; set;}
    }
}
