using System.Collections.Generic;
using survey_imprecise_api.Models;

namespace survey_imprecise_api.Models
{
    public class QuestionViewModel
    {
        public List<Question> Questions { get; set; }
        public List<Supplier> Suppliers { get; set; }
    }
}