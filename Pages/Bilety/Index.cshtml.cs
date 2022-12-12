using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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


        public string datum { get; set; }


        public async Task OnGetAsync()
        {
            ViewData["id_pasazera"] = new SelectList(_context.Pasazer, "ID", "imie");

            Bilet = await _context.Bilet
                .Include(b => b.Bagaz)
                .Include(b => b.Lot)
                .Include(b => b.Pasazer).ToListAsync();

            var data = await _context.Lot
                .Include(l => l.Kapitan)
                .Include(l => l.Lotnisko)
                .Include(l => l.Lotnisko_Koncowe)
                .Include(l => l.Oficer)
                .Include(l => l.Samolot).ToListAsync();

            foreach (var val in data)
            {
               /* if (val.id_lotu == Bilet.id_lotu)
                {
                    datum = val.ToString();
                }*/
            }
        }
    }
}
