using System.Text.Json.Serialization;
namespace survey_imprecise_api.Models
{
    public class CaseParameter
    {
        public int CaseParameterId { get; set; }

        [JsonIgnore]
        public virtual Case Case { get; set; }
        public int Indicator { get; set; }
        public int Score { get; set; }
        public string DescriptionOne { get; set; }
        public string DescriptionTwo { get; set; }
    }
}
