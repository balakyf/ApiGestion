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
    public class EventLogsController : ControllerBase
    {
        private readonly ModelsContext _context;

        public EventLogsController(ModelsContext context)
        {
            _context = context;
        }

        // GET: api/EventLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventLog>>> GetEventLog()
        {
            return await _context.EventLog.ToListAsync();
        }

        // GET: api/EventLogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventLog>> GetEventLog(Guid id)
        {
            var eventLog = await _context.EventLog.FindAsync(id);

            if (eventLog == null)
            {
                return NotFound();
            }

            return eventLog;
        }

        // PUT: api/EventLogs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEventLog(Guid id, EventLog eventLog)
        {
            if (id != eventLog.Id)
            {
                return BadRequest();
            }

            _context.Entry(eventLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventLogExists(id))
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

        // POST: api/EventLogs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EventLog>> PostEventLog(EventLog eventLog)
        {
            _context.EventLog.Add(eventLog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEventLog", new { id = eventLog.Id }, eventLog);
        }

        // DELETE: api/EventLogs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EventLog>> DeleteEventLog(Guid id)
        {
            var eventLog = await _context.EventLog.FindAsync(id);
            if (eventLog == null)
            {
                return NotFound();
            }

            _context.EventLog.Remove(eventLog);
            await _context.SaveChangesAsync();

            return eventLog;
        }

        private bool EventLogExists(Guid id)
        {
            return _context.EventLog.Any(e => e.Id == id);
        }
    }
}
