﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MatanzaBikes.Data;
using MatanzaBikes.Model;

namespace MatanzaBikes.Pages.Marcas
{
    public class DeleteModel : PageModel
    {
        private readonly MatanzaBikes.Data.MatanzaBikesContext _context;

        public DeleteModel(MatanzaBikes.Data.MatanzaBikesContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Marca Marca { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Marcas == null)
            {
                return NotFound();
            }

            var marca = await _context.Marcas.FirstOrDefaultAsync(m => m.Id == id);

            if (marca == null)
            {
                return NotFound();
            }
            else 
            {
                Marca = marca;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Marcas == null)
            {
                return NotFound();
            }
            var marca = await _context.Marcas.FindAsync(id);

            if (marca != null)
            {
                Marca = marca;
                _context.Marcas.Remove(Marca);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
