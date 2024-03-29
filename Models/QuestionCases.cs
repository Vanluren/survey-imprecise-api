using Newtonsoft.Json;

namespace survey_imprecise_api.Models
{
    public class QuestionCases
    {
        [JsonIgnore]
        public virtual int? QuestionId { get; set; }
        [JsonIgnore]
        public virtual Question Question { get; set; }
        [JsonIgnore]
        public virtual int? CaseId { get; set; }
        public virtual Case Case { get; set; }
    }
}