using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MatanzaBikes.Data;
using MatanzaBikes.Model;

namespace MatanzaBikes.Pages.Motos
{
    public class DetailsModel : PageModel
    {
        private readonly MatanzaBikes.Data.MatanzaBikesContext _context;

        public DetailsModel(MatanzaBikes.Data.MatanzaBikesContext context)
        {
            _context = context;
        }

      public Moto Moto { get; set; } = default!;

        public IList<Marca> Marca { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Motos == null)
            {
                return NotFound();
            }

            var moto = await _context.Motos.FirstOrDefaultAsync(m => m.Id == id);
            if (moto == null)
            {
                return NotFound();
            }
            else 
            {
                Moto = moto;
            }

            if (_context.Marcas != null)
            {
                Marca = await _context.Marcas.ToListAsync();
            }

            return Page();
        }
    }
}
