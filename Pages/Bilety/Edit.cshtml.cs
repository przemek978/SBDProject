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
    public class EditModel : PageModel
    {
        private readonly SBD.Data.AirPortContext _context;

        public EditModel(SBD.Data.AirPortContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Bilet Bilet { get; set; }

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

            var selBag = _context.Bagaz.Select(c => new SelectListItem
            {
                Value = c.id_bagazu.ToString(),
                Text = c.id_bagazu.ToString() + " - " + c.waga.ToString() + "kg"
            });
            var selPas = _context.Pasazer.Select(c => new SelectListItem
            {
                Value = c.id_pasazera.ToString(),
                Text = c.id_pasazera.ToString() + " - " + c.imie.ToString() + " " + c.nazwisko.ToString()
            });

            //ViewData["id_kapitana"] = new SelectList(selectPilot, "Value", "Text");

            ViewData["id_bagazu"] = new SelectList(selBag, "Value", "Text");
            ViewData["id_lotu"] = new SelectList(_context.Lot, "id_lotu", "id_lotu");
            ViewData["id_pasazera"] = new SelectList(selPas, "Value", "Text");
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

            _context.Attach(Bilet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BiletExists(Bilet.id_biletu))
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

        private bool BiletExists(int id)
        {
            return _context.Bilet.Any(e => e.id_biletu == id);
        }
    }
}
