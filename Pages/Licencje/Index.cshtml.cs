using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SBD.Data;
using SBD.Models;

namespace SBD.Pages.Licencje
{
    public class IndexModel : PageModel
    {
        private readonly SBD.Data.AirPortContext _context;

        public IndexModel(SBD.Data.AirPortContext context)
        {
            _context = context;
        }

        public IList<Licencja> Licencja { get;set; }

        public async Task OnGetAsync()
        {
            Licencja = await _context.Licencja
                .Include(l => l.Pilot).ToListAsync();
        }
    }
}
