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

namespace SBD.Pages.LinieLotnicze
{
    public class EditModel : PageModel
    {
        private readonly SBD.Data.AirPortContext _context;

        public EditModel(SBD.Data.AirPortContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LiniaLotnicza LiniaLotnicza { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LiniaLotnicza = await _context.LiniaLotnicza.FirstOrDefaultAsync(m => m.kod == id);

            if (LiniaLotnicza == null)
            {
                return NotFound();
            }
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

            _context.Attach(LiniaLotnicza).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LiniaLotniczaExists(LiniaLotnicza.kod))
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

        private bool LiniaLotniczaExists(string id)
        {
            return _context.LiniaLotnicza.Any(e => e.kod == id);
        }
    }
}
