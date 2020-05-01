using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace survey_imprecise_api.Models
{
    public class Respondant
    {
        public Respondant()
        {
            Rankings = new HashSet<Ranking>();
            Responses = new HashSet<Response>();
        }

        public int RespondantId { get; set; }
        public string Occupation { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<Ranking> Rankings { get; set; }
        public virtual ICollection<Response> Responses { get; set; }
    }

}
