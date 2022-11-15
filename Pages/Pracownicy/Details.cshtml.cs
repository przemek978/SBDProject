using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SBD.Data;
using SBD.Models;

namespace SBD.Pages.Pracownicy
{
    public class DetailsModel : PageModel
    {
        private readonly SBD.Data.AirPortContext _context;

        public DetailsModel(SBD.Data.AirPortContext context)
        {
            _context = context;
        }

        public Pracownik Pracownik { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pracownik = await _context.Pracownik
                .Include(p => p.Lotnisko).FirstOrDefaultAsync(m => m.id_pracownika == id);

            if (Pracownik == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
