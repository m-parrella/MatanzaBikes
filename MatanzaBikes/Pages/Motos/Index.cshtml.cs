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
    public class IndexModel : PageModel
    {
        private readonly MatanzaBikes.Data.MatanzaBikesContext _context;

        public IndexModel(MatanzaBikes.Data.MatanzaBikesContext context)
        {
            _context = context;
        }

        public IList<Moto> Moto { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Motos != null)
            {
                Moto = await _context.Motos.ToListAsync();
            }
        }
    }
}
