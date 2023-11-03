using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MatanzaBikes.Data;
using MatanzaBikes.Model;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MatanzaBikes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcasController : ControllerBase
    {
        private readonly MatanzaBikesContext _context;

        public MarcasController(MatanzaBikesContext context)
        {
            _context = context;
        }

        // GET: api/Marcas
        /// <summary>Obtiene un listado con todas las Marcas.</summary>
        /// <param name="column" example="nombre"></param>
        /// <param name="keyword" example="Honda"></param>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Marca>>> GetMarcas(string? column = null, string? keyword = null)
        {
            var marcas = new List<Marca>();
            
            if (_context.Marcas == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(column) && !string.IsNullOrEmpty(keyword))
            {
                var filter = $"%{keyword}%";
                switch (column)
                {
                    case "nombre":
                        marcas = _context.Marcas.Where(m => EF.Functions.Like(m.Nombre, filter)).ToList();
                        break;
                    case "id":
                        if (int.TryParse(keyword, out var id))
                        {
                            marcas = _context.Marcas.Where(m => m.Id == id).ToList();
                        }
                        break;
                    default:
                        return BadRequest(new {message = "Invalid column name"});
                }
            }
            else
            {
                marcas = _context.Marcas.ToList();
            }
                
            return Ok(marcas);
        }

        // GET: api/Marcas/5
        [SwaggerOperation(
            Summary = "Obtiene el detalle de una Marca especìfica."
        )]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Marca>> GetMarca(int id)
        {
            if (_context.Marcas == null)
            {
                return NotFound();
            }
            var marca = await _context.Marcas.FindAsync(id);

            if (marca == null)
            {
                return NotFound();
            }

            return marca;
        }

        // PUT: api/Marcas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [SwaggerOperation(
            Summary = "Actualiza el detalle de una Marca especìfica."
        )]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutMarca(int id, Marca marca)
        {
            if (id != marca.Id)
            {
                return BadRequest();
            }

            _context.Entry(marca).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarcaExists(id))
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

        // POST: api/Marcas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [SwaggerOperation(
            Summary = "Agrega una nueva Marca de Motos."
        )]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Marca>> PostMarca(Marca marca)
        {
            if (_context.Marcas == null)
            {
                return Problem("Entity set 'MatanzaBikesContext.Marcas'  is null.");
            }
            _context.Marcas.Add(marca);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMarca", new { id = marca.Id }, marca);
        }

        // DELETE: api/Marcas/5
        [SwaggerOperation(
            Summary = "Elimina una Marca especìfica."
        )]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteMarca(int id)
        {
            if (_context.Marcas == null)
            {
                return NotFound();
            }
            var marca = await _context.Marcas.FindAsync(id);
            if (marca == null)
            {
                return NotFound();
            }

            _context.Marcas.Remove(marca);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MarcaExists(int id)
        {
            return (_context.Marcas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
