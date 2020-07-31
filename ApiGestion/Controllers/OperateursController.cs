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
    public class OperateursController : ControllerBase
    {
        private readonly ModelsContext _context;

        public OperateursController(ModelsContext context)
        {
            _context = context;
        }

        // GET: api/Operateurs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Operateur>>> GetOperateu()
        {
            return await _context.Operateu.ToListAsync();
        }

        // GET: api/Operateurs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Operateur>> GetOperateur(Guid id)
        {
            var operateur = await _context.Operateu.FindAsync(id);

            if (operateur == null)
            {
                return NotFound();
            }

            return operateur;
        }

        // PUT: api/Operateurs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOperateur(Guid id, Operateur operateur)
        {
            if (id != operateur.Id)
            {
                return BadRequest();
            }

            _context.Entry(operateur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OperateurExists(id))
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

        // POST: api/Operateurs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Operateur>> PostOperateur(Operateur operateur)
        {
            _context.Operateu.Add(operateur);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOperateur", new { id = operateur.Id }, operateur);
        }

        // DELETE: api/Operateurs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Operateur>> DeleteOperateur(Guid id)
        {
            var operateur = await _context.Operateu.FindAsync(id);
            if (operateur == null)
            {
                return NotFound();
            }

            _context.Operateu.Remove(operateur);
            await _context.SaveChangesAsync();

            return operateur;
        }

        private bool OperateurExists(Guid id)
        {
            return _context.Operateu.Any(e => e.Id == id);
        }
    }
}
