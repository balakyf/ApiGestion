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
    public class PaniersController : ControllerBase
    {
        private readonly ModelsContext _context;

        public PaniersController(ModelsContext context)
        {
            _context = context;
        }

        // GET: api/Paniers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Panier>>> GetPanier()
        {
            return await _context.Panier.ToListAsync();
        }

        // GET: api/Paniers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Panier>> GetPanier(Guid id)
        {
            var panier = await _context.Panier.FindAsync(id);

            if (panier == null)
            {
                return NotFound();
            }

            return panier;
        }

        // PUT: api/Paniers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPanier(Guid id, Panier panier)
        {
            if (id != panier.Id)
            {
                return BadRequest();
            }

            _context.Entry(panier).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PanierExists(id))
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

        // POST: api/Paniers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Panier>> PostPanier(Panier panier)
        {
            _context.Panier.Add(panier);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPanier", new { id = panier.Id }, panier);
        }

        // DELETE: api/Paniers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Panier>> DeletePanier(Guid id)
        {
            var panier = await _context.Panier.FindAsync(id);
            if (panier == null)
            {
                return NotFound();
            }

            _context.Panier.Remove(panier);
            await _context.SaveChangesAsync();

            return panier;
        }

        private bool PanierExists(Guid id)
        {
            return _context.Panier.Any(e => e.Id == id);
        }
    }
}
