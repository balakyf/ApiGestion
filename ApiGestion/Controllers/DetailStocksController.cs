using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiGestion.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace ApiGestion.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class DetailStocksController : ControllerBase
    {
        private readonly ModelsContext _context;

        public DetailStocksController(ModelsContext context)
        {
            _context = context;
        }

        // GET: api/DetailStocks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetailStock>>> GetDetailStock()
        {
            return await _context.DetailStock.ToListAsync();
        }

        // GET: api/DetailStocks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetailStock>> GetDetailStock(Guid id)
        {
            var detailStock = await _context.DetailStock.FindAsync(id);

            if (detailStock == null)
            {
                return NotFound();
            }

            return detailStock;
        }

        // PUT: api/DetailStocks/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetailStock(Guid id, DetailStock detailStock)
        {
            if (id != detailStock.Id)
            {
                return BadRequest();
            }

            _context.Entry(detailStock).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetailStockExists(id))
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

        // POST: api/DetailStocks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DetailStock>> PostDetailStock(DetailStock detailStock)
        {
            _context.DetailStock.Add(detailStock);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetailStock", new { id = detailStock.Id }, detailStock);
        }

        // DELETE: api/DetailStocks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DetailStock>> DeleteDetailStock(Guid id)
        {
            var detailStock = await _context.DetailStock.FindAsync(id);
            if (detailStock == null)
            {
                return NotFound();
            }

            _context.DetailStock.Remove(detailStock);
            await _context.SaveChangesAsync();

            return detailStock;
        }

        private bool DetailStockExists(Guid id)
        {
            return _context.DetailStock.Any(e => e.Id == id);
        }
    }
}
