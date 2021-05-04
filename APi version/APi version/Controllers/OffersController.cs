using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APi_version.Models;

namespace APi_version.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffersController : ControllerBase
    {
        private readonly AppDBContext _context;

        public OffersController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/Offers
        [HttpGet]
        public IEnumerable<Offers> GetOffers()
        {
            return _context.Offers;
        }

        // GET: api/Offers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOffers([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var offers = await _context.Offers.FindAsync(id);

            if (offers == null)
            {
                return NotFound();
            }

            return Ok(offers);
        }

        // PUT: api/Offers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOffers([FromRoute] int id, [FromBody] Offers offers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != offers.ID)
            {
                return BadRequest();
            }

            _context.Entry(offers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OffersExists(id))
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

        // POST: api/Offers
        [HttpPost]
        public async Task<IActionResult> PostOffers([FromBody] Offers offers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Offers.Add(offers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOffers", new { id = offers.ID }, offers);
        }

        // DELETE: api/Offers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOffers([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var offers = await _context.Offers.FindAsync(id);
            if (offers == null)
            {
                return NotFound();
            }

            _context.Offers.Remove(offers);
            await _context.SaveChangesAsync();

            return Ok(offers);
        }

        private bool OffersExists(int id)
        {
            return _context.Offers.Any(e => e.ID == id);
        }
    }
}