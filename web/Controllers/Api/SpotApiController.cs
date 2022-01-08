using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web.Data;
using web.Models;

namespace web.Controllers_Api
{
    [Route("api/v1/Spot")]
    [ApiController]
    public class SpotApiController : ControllerBase
    {
        private readonly ParkingContext _context;

        public SpotApiController(ParkingContext context)
        {
            _context = context;
        }

        // GET: api/SpotApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Spot>>> GetSpot()
        {
            return await _context.Spot.ToListAsync();
        }

        // GET: api/SpotApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Spot>> GetSpot(int id)
        {
            var spot = await _context.Spot.FindAsync(id);

            if (spot == null)
            {
                return NotFound();
            }

            return spot;
        }

        // PUT: api/SpotApi/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpot(int id, Spot spot)
        {
            if (id != spot.SpotID)
            {
                return BadRequest();
            }

            _context.Entry(spot).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpotExists(id))
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

        // POST: api/SpotApi
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Spot>> PostSpot(Spot spot)
        {
            _context.Spot.Add(spot);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSpot", new { id = spot.SpotID }, spot);
        }

        // DELETE: api/SpotApi/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Spot>> DeleteSpot(int id)
        {
            var spot = await _context.Spot.FindAsync(id);
            if (spot == null)
            {
                return NotFound();
            }

            _context.Spot.Remove(spot);
            await _context.SaveChangesAsync();

            return spot;
        }

        private bool SpotExists(int id)
        {
            return _context.Spot.Any(e => e.SpotID == id);
        }
    }
}
