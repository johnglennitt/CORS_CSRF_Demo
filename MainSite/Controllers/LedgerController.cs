using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MainSite.Data;
using MainSite.Data.Models;

namespace MainSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LedgerController : ControllerBase
    {
        private readonly Context _context;

        public LedgerController(Context context)
        {
            _context = context;
        }

        // GET: api/Ledger
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LedgerEntry>>> GetLedgerEntries()
        {
            return await _context.LedgerEntries.ToListAsync();
        }

        // GET: api/Ledger/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LedgerEntry>> GetLedgerEntry(int id)
        {
            var ledgerEntry = await _context.LedgerEntries.FindAsync(id);

            if (ledgerEntry == null)
            {
                return NotFound();
            }

            return ledgerEntry;
        }

        // PUT: api/Ledger/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLedgerEntry(int id, LedgerEntry ledgerEntry)
        {
            if (id != ledgerEntry.Id)
            {
                return BadRequest();
            }

            _context.Entry(ledgerEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LedgerEntryExists(id))
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

        // POST: api/Ledger
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LedgerEntry>> PostLedgerEntry(LedgerEntry ledgerEntry)
        {
            _context.LedgerEntries.Add(ledgerEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLedgerEntry", new { id = ledgerEntry.Id }, ledgerEntry);
        }

        // DELETE: api/Ledger/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLedgerEntry(int id)
        {
            var ledgerEntry = await _context.LedgerEntries.FindAsync(id);
            if (ledgerEntry == null)
            {
                return NotFound();
            }

            _context.LedgerEntries.Remove(ledgerEntry);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LedgerEntryExists(int id)
        {
            return _context.LedgerEntries.Any(e => e.Id == id);
        }
    }
}
