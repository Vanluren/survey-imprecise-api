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
    public class CaseParametersController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public CaseParametersController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/CaseParameters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CaseParameter>>> GetCaseParameters()
        {
            return await _context.CaseParameters.ToListAsync();
        }

        // GET: api/CaseParameters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CaseParameter>> GetCaseParameter(int id)
        {
            var caseParameter = await _context.CaseParameters.FindAsync(id);

            if (caseParameter == null)
            {
                return NotFound();
            }

            return caseParameter;
        }

        // PUT: api/CaseParameters/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCaseParameter(int id, CaseParameter caseParameter)
        {
            if (id != caseParameter.CaseParameterId)
            {
                return BadRequest();
            }

            _context.Entry(caseParameter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaseParameterExists(id))
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

        // POST: api/CaseParameters
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CaseParameter>> PostCaseParameter(CaseParameter caseParameter)
        {
            _context.CaseParameters.Add(caseParameter);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCaseParameter", new { id = caseParameter.CaseParameterId }, caseParameter);
        }

        // DELETE: api/CaseParameters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CaseParameter>> DeleteCaseParameter(int id)
        {
            var caseParameter = await _context.CaseParameters.FindAsync(id);
            if (caseParameter == null)
            {
                return NotFound();
            }

            _context.CaseParameters.Remove(caseParameter);
            await _context.SaveChangesAsync();

            return caseParameter;
        }

        private bool CaseParameterExists(int id)
        {
            return _context.CaseParameters.Any(e => e.CaseParameterId == id);
        }
    }
}
