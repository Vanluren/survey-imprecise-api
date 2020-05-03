using System.ComponentModel.DataAnnotations.Schema;

namespace survey_imprecise_api.Models
{
    public class CaseRanking
    {
        public int RankingId { get; set; }
        public int CaseId { get; set; }
        public int? Priority { get; set; }

        [NotMapped]
        public int[] Rankings { get; set; }

        public virtual Case Case { get; set; }
        public virtual Ranking Ranking { get; set; }
    }
}