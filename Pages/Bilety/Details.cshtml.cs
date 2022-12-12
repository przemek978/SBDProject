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
    public class DetailsModel : PageModel
    {
        private readonly SBD.Data.AirPortContext _context;

        public DetailsModel(SBD.Data.AirPortContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Bilet Bilet { get; set; }

        public string datum { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            Bilet = await _context.Bilet
                .Include(b => b.Bagaz)
                .Include(b => b.Lot)
                .Include(b => b.Pasazer).FirstOrDefaultAsync(m => m.id_biletu == id);


            if (Bilet == null)
            {
                return NotFound();
            }
            


            var data = await _context.Lot
                .Include(l => l.Kapitan)
                .Include(l => l.Lotnisko)
                .Include(l => l.Lotnisko_Koncowe)
                .Include(l => l.Oficer)
                .Include(l => l.Samolot).ToListAsync();

            foreach (var val in data)
            {
                if(val.id_lotu == Bilet.id_lotu)
                {
                    datum = val.ToString();
                }
            }

            return Page();
        }
    }
}
