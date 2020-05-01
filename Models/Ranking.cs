namespace survey_imprecise_api.Models
{
    public class Ranking
    {
        public int RankingId { get; set; }
        public int RespondantId { get; set; }

        public virtual Respondant Respondant { get; set; }
    }
}