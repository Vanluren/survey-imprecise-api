using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace survey_imprecise_api.Models
{
    public class Parameter
    {

        public Parameter()
        {
            CaseParameters = new HashSet<CaseParameter>();
        }

        public int ParameterId { get; set; }

        [Column(TypeName = "nvarchar(24)")]
        [JsonConverter(typeof(StringEnumConverter))]
        public IndicatorType Indicator { get; set; }
        public int Score { get; set; }
        public string DescriptionOne { get; set; }
        public string DescriptionTwo { get; set; }

        public virtual ICollection<CaseParameter> CaseParameters { get; set; }
    }
}