using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiGestion.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace ApiGestion.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class EvenementsController : ControllerBase
    {
        private readonly ModelsContext _context;

        public EvenementsController(ModelsContext context)
        {
            _context = context;
        }

        // GET: api/Evenements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Evenement>>> GetEvenement()
        {
            return await _context.Evenement.ToListAsync();
        }

        // GET: api/Evenements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Evenement>> GetEvenement(Guid id)
        {
            var evenement = await _context.Evenement.FindAsync(id);

            if (evenement == null)
            {
                return NotFound();
            }

            return evenement;
        }

        // PUT: api/Evenements/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvenement(Guid id, Evenement evenement)
        {
            if (id != evenement.Id)
            {
                return BadRequest();
            }

            _context.Entry(evenement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EvenementExists(id))
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

        // POST: api/Evenements
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Evenement>> PostEvenement(Evenement evenement)
        {
            _context.Evenement.Add(evenement);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEvenement", new { id = evenement.Id }, evenement);
        }

        // DELETE: api/Evenements/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Evenement>> DeleteEvenement(Guid id)
        {
            var evenement = await _context.Evenement.FindAsync(id);
            if (evenement == null)
            {
                return NotFound();
            }

            _context.Evenement.Remove(evenement);
            await _context.SaveChangesAsync();

            return evenement;
        }

        private bool EvenementExists(Guid id)
        {
            return _context.Evenement.Any(e => e.Id == id);
        }
    }
}
