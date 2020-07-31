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
    public class TypeOperationsController : ControllerBase
    {
        private readonly ModelsContext _context;

        public TypeOperationsController(ModelsContext context)
        {
            _context = context;
        }

        // GET: api/TypeOperations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeOperation>>> GetTypeOperation()
        {
            return await _context.TypeOperation.ToListAsync();
        }

        // GET: api/TypeOperations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeOperation>> GetTypeOperation(Guid id)
        {
            var typeOperation = await _context.TypeOperation.FindAsync(id);

            if (typeOperation == null)
            {
                return NotFound();
            }

            return typeOperation;
        }

        // PUT: api/TypeOperations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeOperation(Guid id, TypeOperation typeOperation)
        {
            if (id != typeOperation.Id)
            {
                return BadRequest();
            }

            _context.Entry(typeOperation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeOperationExists(id))
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

        // POST: api/TypeOperations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TypeOperation>> PostTypeOperation(TypeOperation typeOperation)
        {
            _context.TypeOperation.Add(typeOperation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTypeOperation", new { id = typeOperation.Id }, typeOperation);
        }

        // DELETE: api/TypeOperations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TypeOperation>> DeleteTypeOperation(Guid id)
        {
            var typeOperation = await _context.TypeOperation.FindAsync(id);
            if (typeOperation == null)
            {
                return NotFound();
            }

            _context.TypeOperation.Remove(typeOperation);
            await _context.SaveChangesAsync();

            return typeOperation;
        }

        private bool TypeOperationExists(Guid id)
        {
            return _context.TypeOperation.Any(e => e.Id == id);
        }
    }
}
