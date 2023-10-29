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
    public class DeleteModel : PageModel
    {
        private readonly MatanzaBikes.Data.MatanzaBikesContext _context;

        public DeleteModel(MatanzaBikes.Data.MatanzaBikesContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Moto Moto { get; set; } = default!;

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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Motos == null)
            {
                return NotFound();
            }
            var moto = await _context.Motos.FindAsync(id);

            if (moto != null)
            {
                Moto = moto;
                _context.Motos.Remove(Moto);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
