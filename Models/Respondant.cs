using System.Collections.Generic;

namespace survey_imprecise_api.Models
{
    public class Respondant
    {
        public int RespondantId { get; set; }
        public string Occupation { get; set; }
        public virtual List<Response> Responses { get; set; }

    }
}