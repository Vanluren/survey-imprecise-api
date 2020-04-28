namespace survey_imprecise_api.Models
{
    public class QuestionCases
    {
        public virtual int? QuestionId { get; set; }
        public virtual Question Question { get; set; }
        public virtual int? CaseId { get; set; }
        public virtual Case Case { get; set; }
    }
}