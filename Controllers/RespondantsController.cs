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
    public class RespondantsController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public RespondantsController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/Respondants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Respondant>>> GetRespondants()
        {
            return await _context.Respondants.ToListAsync();
        }

        // GET: api/Respondants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Respondant>> GetRespondant(int id)
        {
            var respondant = await _context.Respondants.FindAsync(id);

            if (respondant == null)
            {
                return NotFound();
            }

            return respondant;
        }

        // PUT: api/Respondants/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRespondant(int id, Respondant respondant)
        {
            if (id != respondant.RespondantId)
            {
                return BadRequest();
            }

            _context.Entry(respondant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RespondantExists(id))
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

        // POST: api/Respondants
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Respondant>> PostRespondant(Respondant respondant)
        {
            _context.Respondants.Add(respondant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRespondant", new { id = respondant.RespondantId }, respondant);
        }

        // DELETE: api/Respondants/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Respondant>> DeleteRespondant(int id)
        {
            var respondant = await _context.Respondants.FindAsync(id);
            if (respondant == null)
            {
                return NotFound();
            }

            _context.Respondants.Remove(respondant);
            await _context.SaveChangesAsync();

            return respondant;
        }

        private bool RespondantExists(int id)
        {
            return _context.Respondants.Any(e => e.RespondantId == id);
        }
    }
}
