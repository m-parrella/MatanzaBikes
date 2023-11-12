using System;
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
    public class IndexModel : PageModel
    {
        private readonly MatanzaBikes.Data.MatanzaBikesContext _context;

        public IndexModel(MatanzaBikes.Data.MatanzaBikesContext context)
        {
            _context = context;
        }

        public string CurrentFilter { get; set; }
        public IList<Marca> Marca { get;set; } = default!;

        public async Task OnGetAsync(string searchString)
        {
            CurrentFilter = searchString;

            if (_context.Marcas != null)
            {
                Marca = await _context.Marcas.ToListAsync();
                if (!String.IsNullOrEmpty(searchString))
                {
                    var filter = $"%{searchString}%";
                    Marca = await _context.Marcas.Where(m =>
                        EF.Functions.Like(m.Nombre, filter)
                        ).ToListAsync();
                }
            }
        }
    }
}
