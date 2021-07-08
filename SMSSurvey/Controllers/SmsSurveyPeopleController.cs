using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SMSSurvey.Models;

namespace SMSSurvey.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsSurveyPeopleController : ControllerBase
    {
        private readonly SmsSurveyContext _context;

        public SmsSurveyPeopleController(SmsSurveyContext context)
        {
            _context = context;
        }

        // GET: api/SmsSurveyPeople
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SmsSurveyPerson>>> GetSmsSurveyPeople()
        {
            return await _context.SmsSurveyPeople.ToListAsync();
        }

        // GET: api/SmsSurveyPeople/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SmsSurveyPerson>> GetSmsSurveyPerson(string id)
        {
            var smsSurveyPerson = await _context.SmsSurveyPeople.FindAsync(id);

            if (smsSurveyPerson == null)
            {
                return NotFound();
            }

            return smsSurveyPerson;
        }

        // PUT: api/SmsSurveyPeople/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSmsSurveyPerson(string id, SmsSurveyPerson smsSurveyPerson)
        {
            if (id != smsSurveyPerson.Id)
            {
                return BadRequest();
            }

            _context.Entry(smsSurveyPerson).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SmsSurveyPersonExists(id))
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

        // POST: api/SmsSurveyPeople
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SmsSurveyPerson>> PostSmsSurveyPerson(SmsSurveyPerson smsSurveyPerson)
        {
            smsSurveyPerson.Id = Guid.NewGuid().ToString();
            _context.SmsSurveyPeople.Add(smsSurveyPerson);
            try
            {
                
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SmsSurveyPersonExists(smsSurveyPerson.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSmsSurveyPerson", new { id = smsSurveyPerson.Id }, smsSurveyPerson);
        }

        // DELETE: api/SmsSurveyPeople/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSmsSurveyPerson(string id)
        {
            var smsSurveyPerson = await _context.SmsSurveyPeople.FindAsync(id);
            if (smsSurveyPerson == null)
            {
                return NotFound();
            }

            _context.SmsSurveyPeople.Remove(smsSurveyPerson);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SmsSurveyPersonExists(string id)
        {
            return _context.SmsSurveyPeople.Any(e => e.Id == id);
        }
    }
}
