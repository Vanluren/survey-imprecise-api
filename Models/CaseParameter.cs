using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace survey_imprecise_api.Models
{
    public class CaseParameter
    {
        public int CaseParameterId { get; set; }
        [Column(TypeName = "nvarchar(24)")]
        [JsonConverter(typeof(StringEnumConverter))]
        public IndicatorType Indicator { get; set; }
        public int Score { get; set; }
        public string DescriptionOne { get; set; }
        public string DescriptionTwo { get; set; }
    }
}
