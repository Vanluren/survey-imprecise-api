using System.Collections.Generic;

namespace survey_imprecise_api.Models
{
    public class Response
    {
        public int ResponseId { get; set; }
        public virtual Respondant Respondant { get; set; }
        public virtual Case ChosenCase { get; set; }
        public virtual List<Case> Choices { get; set; }
    }
}