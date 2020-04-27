namespace survey_imprecise_api.Models
{
    public class CaseParameter
    {
        public int CaseParameterId { get; set; }
        public Case Case { get; set; }

        public string Title { get; set; }
        public string DescriptionOne { get; set; }
        public string DescriptionTwo { get; set; }
    }
}
