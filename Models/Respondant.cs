using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace survey_imprecise_api.Models
{
    public class Respondant
    {
        public int RespondantId { get; set; }
        public string Occupation { get; set; }
        public virtual List<Response> Responses { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; }

    }
}
