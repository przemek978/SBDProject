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

namespace SBD.Pages.Loty
{
    public class EditModel : PageModel
    {
        private readonly SBD.Data.AirPortContext _context;

        public EditModel(SBD.Data.AirPortContext context)
        {
            _context = context;
        }

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
           ViewData["id_kapitana"] = new SelectList(_context.Pilot, "id_pilota", "id_pilota");
           ViewData["id_lotniska_startowego"] = new SelectList(_context.Lotnisko, "id_lotniska", "id_lotniska");
           ViewData["id_lotniska_koncowego"] = new SelectList(_context.Lotnisko, "id_lotniska", "id_lotniska");
           ViewData["id_oficera"] = new SelectList(_context.Pilot, "id_pilota", "id_pilota");
           ViewData["id_samolotu"] = new SelectList(_context.Samolot, "id_samolotu", "id_samolotu");
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

            _context.Attach(Lot).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LotExists(Lot.id_lotu))
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

        private bool LotExists(int id)
        {
            return _context.Lot.Any(e => e.id_lotu == id);
        }
    }
}
