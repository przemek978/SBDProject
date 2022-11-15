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
    public class DeleteModel : PageModel
    {
        private readonly SBD.Data.AirPortContext _context;

        public DeleteModel(SBD.Data.AirPortContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Licencja Licencja { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Licencja = await _context.Licencja
                .Include(l => l.Pilot).FirstOrDefaultAsync(m => m.id_licencji == id);

            if (Licencja == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Licencja = await _context.Licencja.FindAsync(id);

            if (Licencja != null)
            {
                _context.Licencja.Remove(Licencja);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
