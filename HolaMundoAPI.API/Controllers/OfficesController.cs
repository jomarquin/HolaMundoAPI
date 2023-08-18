﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HolaMundoAPI.API.Data;
using HolaMundoAPI.API.Data.Models;

namespace HolaMundoAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficesController : ControllerBase
    {
        private readonly HolaMundoDbContext _context;

        public OfficesController(HolaMundoDbContext context)
        {
            _context = context;
        }

        // GET: api/Offices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Office>>> GetOffice()
        {
          if (_context.Offices == null)
          {
              return NotFound();
          }
            return await _context.Offices.ToListAsync();
        }

        // GET: api/Offices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Office>> GetOffice(long id)
        {
          if (_context.Offices == null)
          {
              return NotFound();
          }
            var office = await _context.Offices.FindAsync(id);

            if (office == null)
            {
                return NotFound();
            }

            return office;
        }

        // PUT: api/Offices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOffice(long id, Office office)
        {
            if (id != office.Id)
            {
                return BadRequest();
            }

            _context.Entry(office).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OfficeExists(id))
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

        // POST: api/Offices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Office>> PostOffice(Office office)
        {
          if (_context.Offices == null)
          {
              return Problem("Entity set 'HolaMundoDbContext.Office'  is null.");
          }
            _context.Offices.Add(office);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOffice", new { id = office.Id }, office);
        }

        // DELETE: api/Offices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOffice(long id)
        {
            if (_context.Offices == null)
            {
                return NotFound();
            }
            var office = await _context.Offices.FindAsync(id);
            if (office == null)
            {
                return NotFound();
            }

            _context.Offices.Remove(office);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OfficeExists(long id)
        {
            return (_context.Offices?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
