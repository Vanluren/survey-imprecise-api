using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using survey_imprecise_api.Data;
using survey_imprecise_api.Models;

namespace survey_imprecise_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RankingsController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public RankingsController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/Rankings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ranking>>> GetRankings()
        {
            return await _context.Rankings.ToListAsync();
        }

        // GET: api/Rankings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ranking>> GetRanking(int id)
        {
            var ranking = await _context.Rankings.FindAsync(id);

            if (ranking == null)
            {
                return NotFound();
            }

            return ranking;
        }

        // PUT: api/Rankings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRanking(int id, Ranking ranking)
        {
            if (id != ranking.RankingId)
            {
                return BadRequest();
            }

            _context.Entry(ranking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RankingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Rankings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Ranking>> PostRanking(Ranking ranking)
        {
            _context.Rankings.Add(ranking);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRanking", new { id = ranking.RankingId }, ranking);
        }

        // DELETE: api/Rankings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Ranking>> DeleteRanking(int id)
        {
            var ranking = await _context.Rankings.FindAsync(id);
            if (ranking == null)
            {
                return NotFound();
            }

            _context.Rankings.Remove(ranking);
            await _context.SaveChangesAsync();

            return ranking;
        }

        private bool RankingExists(int id)
        {
            return _context.Rankings.Any(e => e.RankingId == id);
        }
    }
}
