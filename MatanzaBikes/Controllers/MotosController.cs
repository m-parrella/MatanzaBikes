﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MatanzaBikes.Data;
using MatanzaBikes.Model;
using Swashbuckle.AspNetCore.Annotations;

namespace MatanzaBikes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotosController : ControllerBase
    {
        private readonly MatanzaBikesContext _context;

        public MotosController(MatanzaBikesContext context)
        {
            _context = context;
        }

        // GET: api/Motos
        /// <summary>Obtiene un listado con todas las Motos.</summary>
        /// <param name="column" example="año"></param>
        /// <param name="keyword" example="2023"></param>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<Moto>>> GetMotos(string? column = null, string? keyword = null)
        {

            var motos = new List<Moto>();

            if (_context.Motos == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(column) && !string.IsNullOrEmpty(keyword))
            {
                var filter = $"%{keyword}%";
                switch (column)
                {
                    case "modelo":
                        motos = _context.Motos.Where(m => EF.Functions.Like(m.Modelo, filter)).ToList();
                        break;
                    case "año":
                        if (int.TryParse(keyword, out var año))
                        {
                            motos = _context.Motos.Where(m => m.Año == año).ToList();
                        }
                        break;
                    default:
                        return BadRequest(new { message = "Invalid column name" });
                }
            }
            else
            {
                motos = _context.Motos.ToList();
            }

            return Ok(motos);

            //return await _context.Motos.ToListAsync();
        }

        // GET: api/Motos/5
        [SwaggerOperation(
            Summary = "Obtiene el detalle de una Moto especìfica."
        )]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Moto>> GetMoto(int id)
        {
            if (_context.Motos == null)
            {
                return NotFound();
            }
            var moto = await _context.Motos.FindAsync(id);

            if (moto == null)
            {
                return NotFound();
            }

            return moto;
        }

        // PUT: api/Motos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [SwaggerOperation(
            Summary = "Actualiza el detalle de una Moto especìfica."
        )]
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutMoto(int id, Moto moto)
        {
            if (id != moto.Id)
            {
                return BadRequest();
            }

            _context.Entry(moto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MotoExists(id))
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

        // POST: api/Motos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [SwaggerOperation(
            Summary = "Agrega una nueva Moto."
        )]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Moto>> PostMoto(Moto moto)
        {
            if (_context.Motos == null)
            {
                return Problem("Entity set 'MatanzaBikesContext.Motos'  is null.");
            }
            _context.Motos.Add(moto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMoto", new { id = moto.Id }, moto);
        }

        // DELETE: api/Motos/5
        [SwaggerOperation(
            Summary = "Elimina una Moto especìfica."
        )]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteMoto(int id)
        {
            if (_context.Motos == null)
            {
                return NotFound();
            }
            var moto = await _context.Motos.FindAsync(id);
            if (moto == null)
            {
                return NotFound();
            }

            _context.Motos.Remove(moto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MotoExists(int id)
        {
            return (_context.Motos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
