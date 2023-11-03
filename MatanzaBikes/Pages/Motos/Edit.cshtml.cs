using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MatanzaBikes.Data;
using MatanzaBikes.Model;

namespace MatanzaBikes.Pages.Motos
{
    public class EditModel : PageModel
    {
        private readonly MatanzaBikes.Data.MatanzaBikesContext _context;

        public EditModel(MatanzaBikes.Data.MatanzaBikesContext context)
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

            var moto =  await _context.Motos.FirstOrDefaultAsync(m => m.Id == id);
            if (moto == null)
            {
                return NotFound();
            }
            Moto = moto;
            ViewData["MarcaId"] = new SelectList(_context.Marcas, "Id", "Nombre");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Moto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MotoExists(Moto.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MotoExists(int id)
        {
          return (_context.Motos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
