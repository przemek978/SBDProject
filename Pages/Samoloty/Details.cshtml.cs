using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SBD.Data;
using SBD.Models;

namespace SBD.Pages.Samoloty
{
    public class DetailsModel : PageModel
    {
        private readonly SBD.Data.AirPortContext _context;

        public DetailsModel(SBD.Data.AirPortContext context)
        {
            _context = context;
        }

        public Samolot Samolot { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Samolot = await _context.Samolot
                .Include(s => s.LiniaLotnicza).FirstOrDefaultAsync(m => m.id_samolotu == id);

            if (Samolot == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
