namespace survey_imprecise_api.Models
{
    public class CaseParameter
    {
        public int CaseParameterId { get; set; }
        public Supplier SupplierId { get; set; }
        public Case CaseId { get; set; }

        public string Title { get; set; }
        public string DescriptionOne { get; set; }
        public string DescriptionTwo { get; set; }
    }
}
