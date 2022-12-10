using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SBD.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SBD.Pages.Bilety
{
    public class ListaModel : PageModel
    {
        private readonly SBD.Data.AirPortContext _context;

        public ListaModel(SBD.Data.AirPortContext context)
        {
            _context = context;
        }
        public IList<Bilet> Bilet { get; set; }
        [BindProperty]
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

            ViewData["id_pasazera"] = new SelectList(_context.Pasazer, "ID", "imie");

            Bilet = await _context.Bilet
                .Include(b => b.Bagaz)
                .Include(b => b.Lot)
                .Include(b => b.Pasazer).ToListAsync();

            return Page();
        }
    }
}
