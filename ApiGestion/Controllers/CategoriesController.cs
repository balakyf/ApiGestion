using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiGestion.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Net;
using Microsoft.AspNetCore.Authorization;

namespace ApiGestion.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ModelsContext _context;

        public CategoriesController(ModelsContext context)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categorie>>> GetCategorie()
        {
            return await _context.Categorie.ToListAsync();
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Categorie>> GetCategorie(Guid id)
        {
            var categorie = await _context.Categorie.FindAsync(id);

            if (categorie == null)
            {
                return NotFound();
            }

            return categorie;
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategorie(Guid id, Categorie categorie)
        {
            if (id != categorie.Id)
            {
                return BadRequest();
            }

            _context.Entry(categorie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategorieExists(id))
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

        // POST: api/Categories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Categorie>> PostCategorie(Categorie categorie)
        {
            _context.Categorie.Add(categorie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategorie", new { id = categorie.Id }, categorie);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Categorie>> DeleteCategorie(Guid id)
        {
            var categorie = await _context.Categorie.FindAsync(id);
            if (categorie == null)
            {
                return NotFound();
            }

            _context.Categorie.Remove(categorie);
            await _context.SaveChangesAsync();

            return categorie;
        }

        private bool CategorieExists(Guid id)
        {
            return _context.Categorie.Any(e => e.Id == id);
        }
    }
}
