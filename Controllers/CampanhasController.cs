using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using cdf_api_integrador.Models;
using cdf_api_integrador.Repositories.Entity;

namespace cdf_api_integrador.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampanhaController : ControllerBase
    {
        private readonly ContextEntity _context;

        public CampanhaController(ContextEntity context)
        {
            _context = context;
        }

        // GET: api/Campanha
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Campanha>>> GetProdutos()
        {
          if (_context.Produtos == null)
          {
              return NotFound();
          }
            return await _context.Produtos.ToListAsync();
        }

        // GET: api/Campanha/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Campanha>> GetCampanha(int id)
        {
          if (_context.Produtos == null)
          {
              return NotFound();
          }
            var campanha = await _context.Produtos.FindAsync(id);

            if (campanha == null)
            {
                return NotFound();
            }

            return campanha;
        }

        // PUT: api/Campanha/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCampanha(int id, Campanha campanha)
        {
            if (id != campanha.Id)
            {
                return BadRequest();
            }

            _context.Entry(campanha).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CampanhaExists(id))
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

        // POST: api/Campanha
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Campanha>> PostCampanha(Campanha campanha)
        {
          if (_context.Produtos == null)
          {
              return Problem("Entity set 'ContextEntity.Produtos'  is null.");
          }
            _context.Produtos.Add(campanha);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCampanha", new { id = campanha.Id }, campanha);
        }

        // DELETE: api/Campanha/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCampanha(int id)
        {
            if (_context.Produtos == null)
            {
                return NotFound();
            }
            var campanha = await _context.Produtos.FindAsync(id);
            if (campanha == null)
            {
                return NotFound();
            }

            _context.Produtos.Remove(campanha);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CampanhaExists(int id)
        {
            return (_context.Produtos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
