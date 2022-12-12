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

namespace SBD.Pages.Pracownicy
{
    public class EditModel : PageModel
    {
        private readonly SBD.Data.AirPortContext _context;

        public EditModel(SBD.Data.AirPortContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Pracownik Pracownik { get; set; }
        public string pass { get; set; }
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
            pass = Pracownik.haslo;
            var sel = _context.Lotnisko.Select(c => new SelectListItem
            {
                Value = c.id_lotniska.ToString(),
                Text = c.lokalizacja.ToString() + " - " + c.nazwa.ToString()
            });
            ViewData["id_lotniska"] = new SelectList(sel, "Value", "Text");
            //ViewData["id_lotniska"] = new SelectList(_context.Set<Lotnisko>(), "id_lotniska", "id_lotniska");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string? pass)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Pracownik.haslo = pass;
            _context.Attach(Pracownik).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PracownikExists(Pracownik.id_pracownika))
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

        private bool PracownikExists(int id)
        {
            return _context.Pracownik.Any(e => e.id_pracownika == id);
        }
    }
}
