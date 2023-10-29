using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MatanzaBikes.Data;
using MatanzaBikes.Model;

namespace MatanzaBikes.Pages.Marcas
{
    public class CreateModel : PageModel
    {
        private readonly MatanzaBikes.Data.MatanzaBikesContext _context;

        public CreateModel(MatanzaBikes.Data.MatanzaBikesContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Marca Marca { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Marcas == null || Marca == null)
            {
                return Page();
            }

            _context.Marcas.Add(Marca);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
