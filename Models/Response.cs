using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace survey_imprecise_api.Models
{
    public class Response
    {
        public int ResponseId { get; set; }
        public int? RespondantId { get; set; }
        public int? ChosenCaseId { get; set; }

        public virtual Case ChosenCase { get; set; }
        public virtual Respondant Respondant { get; set; }
    }
}