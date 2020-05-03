using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using survey_imprecise_api.Data;
using survey_imprecise_api.Models;

namespace survey_imprecise_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaseRankingsController : ControllerBase
    {
        private readonly DataBaseContext _context;
        public CaseRankingsController(DataBaseContext context)
        {
            _context = context;
        }
        public class CaseRankingParams
        {
            public List<string> Rankings;
            public int RespondantId;
        }

        // GET: api/Rankings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CaseRanking>>> GetCaseRankings()
        {
            return await _context.CaseRankings.ToListAsync();
        }

        // POST: api/Rankings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Ranking>> PostCaseRanking([FromBody] CaseRankingParams parameters)
        {
            var newRanking = new Ranking
            {
                RespondantId = parameters.RespondantId
            };
            _context.Rankings.Add(newRanking);
            _context.SaveChanges();

            for (int i = 0; i < parameters.Rankings.Count; i++)
            {


                _context.CaseRankings.Add(new CaseRanking
                {
                    RankingId = newRanking.RankingId,
                    CaseId = Int16.Parse(parameters.Rankings[i]),
                    Priority = i
                });

                _context.SaveChanges();

            }

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
