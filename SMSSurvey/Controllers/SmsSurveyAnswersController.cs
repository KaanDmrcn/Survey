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
    public class SmsSurveyAnswersController : ControllerBase
    {
        private readonly SmsSurveyContext _context;

        public SmsSurveyAnswersController(SmsSurveyContext context)
        {
            _context = context;
        }

        // GET: api/SmsSurveyAnswers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SmsSurveyAnswer>>> GetSmsSurveyAnswers()
        {
            return await _context.SmsSurveyAnswers.ToListAsync();
        }

        // GET: api/SmsSurveyAnswers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SmsSurveyAnswer>> GetSmsSurveyAnswer(int id)
        {
            var smsSurveyAnswer = await _context.SmsSurveyAnswers.FindAsync(id);

            if (smsSurveyAnswer == null)
            {
                return NotFound();
            }

            return smsSurveyAnswer;
        }

        // PUT: api/SmsSurveyAnswers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSmsSurveyAnswer(int id, SmsSurveyAnswer smsSurveyAnswer)
        {
            if (id != smsSurveyAnswer.Id)
            {
                return BadRequest();
            }

            _context.Entry(smsSurveyAnswer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SmsSurveyAnswerExists(id))
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

        // POST: api/SmsSurveyAnswers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SmsSurveyAnswer>> PostSmsSurveyAnswer(SmsSurveyAnswer smsSurveyAnswer)
        {
            _context.SmsSurveyAnswers.Add(smsSurveyAnswer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSmsSurveyAnswer", new { id = smsSurveyAnswer.Id }, smsSurveyAnswer);
        }

        // DELETE: api/SmsSurveyAnswers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSmsSurveyAnswer(int id)
        {
            var smsSurveyAnswer = await _context.SmsSurveyAnswers.FindAsync(id);
            if (smsSurveyAnswer == null)
            {
                return NotFound();
            }

            _context.SmsSurveyAnswers.Remove(smsSurveyAnswer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SmsSurveyAnswerExists(int id)
        {
            return _context.SmsSurveyAnswers.Any(e => e.Id == id);
        }
    }
}
