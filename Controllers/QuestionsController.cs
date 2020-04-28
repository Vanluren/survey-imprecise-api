using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using survey_imprecise_api.Data;
using survey_imprecise_api.Models;

namespace survey_imprecise_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly DataBaseContext _context;
        public QuestionsController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/questions
        [HttpGet]
        public ActionResult<QuestionViewModel> GetQuestions()
        {

            List<Question> questions = _context.Questions.ToList();
            List<Supplier> suppliers = _context.Suppliers.ToList();
            QuestionViewModel viewModel = new QuestionViewModel { Questions = questions, Suppliers = suppliers };

            return viewModel;
        }
        // GET: api/questions
        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> GetQuestion(int id)
        {

            Question question = await _context.Questions.FindAsync(id);

            if (question == null)
            {
                return NotFound();
            }
            return question;
        }
    }
}