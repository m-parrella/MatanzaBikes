using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MatanzaBikes.Data;
using MatanzaBikes.Model;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace MatanzaBikes.Pages.Motos
{
    public class IndexModel : PageModel
    {
        private readonly MatanzaBikes.Data.MatanzaBikesContext _context;

        public IndexModel(MatanzaBikes.Data.MatanzaBikesContext context)
        {
            _context = context;
        }

        public string CurrentFilter { get; set; }

        public IList<Moto> Moto { get;set; } = default!;
        public IList<Marca> Marca { get; set; } = default!;

        public async Task OnGetAsync(string searchString)
        {
            CurrentFilter = searchString;

            if (_context.Motos != null)
            {
                Moto = await _context.Motos.ToListAsync();
                if (!String.IsNullOrEmpty(searchString))
                {
                    var filter = $"%{searchString}%";
                    Moto = await _context.Motos.Where(m =>
                        EF.Functions.Like(m.Modelo, filter) ||
                        EF.Functions.Like(m.Cilindrada, filter)
                        ).ToListAsync();
                }
            }
            if (_context.Marcas != null)
            {
                Marca = await _context.Marcas.ToListAsync();
            }
        }
    }
}
