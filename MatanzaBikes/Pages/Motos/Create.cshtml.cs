using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MatanzaBikes.Data;
using MatanzaBikes.Model;

namespace MatanzaBikes.Pages.Motos
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
        public Moto Moto { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Motos == null || Moto == null)
            {
                return Page();
            }

            _context.Motos.Add(Moto);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
