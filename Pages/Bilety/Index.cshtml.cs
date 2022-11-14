using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SBD.Data;
using SBD.Models;

namespace SBD.Pages.Bilety
{
    public class IndexModel : PageModel
    {
        private readonly SBD.Data.AirPortContext _context;

        public IndexModel(SBD.Data.AirPortContext context)
        {
            _context = context;
        }

        public IList<Bilet> Bilet { get;set; }

        public async Task OnGetAsync()
        {
            Bilet = await _context.Bilet
                .Include(b => b.Bagaz).ToListAsync();
        }
    }
}
