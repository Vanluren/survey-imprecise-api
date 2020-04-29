using Newtonsoft.Json;
namespace survey_imprecise_api.Models
{
    public class QuestionSuppliers
    {
        [JsonIgnore]
        public virtual int? QuestionId { get; set; }
        [JsonIgnore]
        public virtual Question Question { get; set; }
        [JsonIgnore]
        public virtual int? SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}