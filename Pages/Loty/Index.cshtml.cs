using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SBD.Data;
using SBD.Models;

namespace SBD.Pages.Loty
{
    public class IndexModel : PageModel
    {
        private readonly SBD.Data.AirPortContext _context;

        public IndexModel(SBD.Data.AirPortContext context)
        {
            _context = context;
        }

        public IList<Lot> Lot { get;set; }

        public async Task OnGetAsync()
        {
            Lot = await _context.Lot
                .Include(l => l.Lotnisko)
                .Include(l => l.Lotnisko_Koncowe)
                .Include(l => l.Samolot).ToListAsync();
        }
    }
}
