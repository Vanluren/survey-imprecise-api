using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace survey_imprecise_api.Models
{
    public class CaseParameter
    {
        [JsonIgnore]
        public virtual int CaseId { get; set; }
        [JsonIgnore]
        public virtual Case Case { get; set; }
        public virtual int ParameterId { get; set; }
        public virtual Parameter Parameter { get; set; }
    }
}
