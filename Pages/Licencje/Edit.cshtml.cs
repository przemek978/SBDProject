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

namespace SBD.Pages.Licencje
{
    public class EditModel : PageModel
    {
        private readonly SBD.Data.AirPortContext _context;

        public EditModel(SBD.Data.AirPortContext context)
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
           ViewData["id_pilota"] = new SelectList(_context.Pilot, "id_pilota", "id_pilota");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Licencja).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LicencjaExists(Licencja.id_licencji))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool LicencjaExists(int id)
        {
            return _context.Licencja.Any(e => e.id_licencji == id);
        }
    }
}
