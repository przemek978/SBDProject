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
    public class DetailsModel : PageModel
    {
        private readonly SBD.Data.AirPortContext _context;

        public DetailsModel(SBD.Data.AirPortContext context)
        {
            _context = context;
        }

        public Lot Lot { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Lot = await _context.Lot
                .Include(l => l.Kapitan)
                .Include(l => l.Lotnisko)
                .Include(l => l.Lotnisko_Koncowe)
                .Include(l => l.Oficer)
                .Include(l => l.Samolot).FirstOrDefaultAsync(m => m.id_lotu == id);

            if (Lot == null)
            {
                return NotFound();
            }



            return Page();
        }

    }
}
