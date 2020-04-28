using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace survey_imprecise_api.Models
{
    public partial class Supplier
    {
        public int SupplierId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public int Soil { get; set; }
        public int Husbandry { get; set; }
        public int Nutrients { get; set; }
        public int Water { get; set; }
        public int Energy { get; set; }
        public int Biodiversity { get; set; }
        public int Workconditions { get; set; }
        public int Lifequality { get; set; }
        public int Economy { get; set; }
        public int Management { get; set; }

        public virtual List<Case> Cases { get; set; }
        public virtual List<CaseParameter> Parameters { get; set; }
    }
}
