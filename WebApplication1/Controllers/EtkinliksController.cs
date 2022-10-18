using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_DataAccess;
using Project_Model;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EtkinliksController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EtkinliksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Etkinliks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Etkinlik>>> GetEtkinliks()
        {
            return await _context.Etkinliks.ToListAsync();
        }

        // GET: api/Etkinliks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Etkinlik>> GetEtkinlik(int id)
        {
            var etkinlik = await _context.Etkinliks.FindAsync(id);

            if (etkinlik == null)
            {
                return NotFound();
            }

            return etkinlik;
        }

        // PUT: api/Etkinliks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEtkinlik(int id, Etkinlik etkinlik)
        {
            if (id != etkinlik.EtkinlikID)
            {
                return BadRequest();
            }

            _context.Entry(etkinlik).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EtkinlikExists(id))
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

        // POST: api/Etkinliks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Etkinlik>> PostEtkinlik(Etkinlik etkinlik)
        {
            _context.Etkinliks.Add(etkinlik);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEtkinlik", new { id = etkinlik.EtkinlikID }, etkinlik);
        }

        // DELETE: api/Etkinliks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEtkinlik(int id)
        {
            var etkinlik = await _context.Etkinliks.FindAsync(id);
            if (etkinlik == null)
            {
                return NotFound();
            }

            _context.Etkinliks.Remove(etkinlik);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EtkinlikExists(int id)
        {
            return _context.Etkinliks.Any(e => e.EtkinlikID == id);
        }
    }
}
