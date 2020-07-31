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
    public class ConfigurationsController : ControllerBase
    {
        private readonly ModelsContext _context;

        public ConfigurationsController(ModelsContext context)
        {
            _context = context;
        }

        // GET: api/Configurations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Configuration>>> GetConfiguration()
        {
            return await _context.Configuration.ToListAsync();
        }

        // GET: api/Configurations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Configuration>> GetConfiguration(Guid id)
        {
            var configuration = await _context.Configuration.FindAsync(id);

            if (configuration == null)
            {
                return NotFound();
            }

            return configuration;
        }

        // PUT: api/Configurations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConfiguration(Guid id, Configuration configuration)
        {
            if (id != configuration.Id)
            {
                return BadRequest();
            }

            _context.Entry(configuration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfigurationExists(id))
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

        // POST: api/Configurations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Configuration>> PostConfiguration(Configuration configuration)
        {
            _context.Configuration.Add(configuration);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetConfiguration", new { id = configuration.Id }, configuration);
        }

        // DELETE: api/Configurations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Configuration>> DeleteConfiguration(Guid id)
        {
            var configuration = await _context.Configuration.FindAsync(id);
            if (configuration == null)
            {
                return NotFound();
            }

            _context.Configuration.Remove(configuration);
            await _context.SaveChangesAsync();

            return configuration;
        }

        private bool ConfigurationExists(Guid id)
        {
            return _context.Configuration.Any(e => e.Id == id);
        }
    }
}
