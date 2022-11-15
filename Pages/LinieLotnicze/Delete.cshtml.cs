using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SBD.Data;
using SBD.Models;

namespace SBD.Pages.LinieLotnicze
{
    public class DeleteModel : PageModel
    {
        private readonly SBD.Data.AirPortContext _context;

        public DeleteModel(SBD.Data.AirPortContext context)
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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LiniaLotnicza = await _context.LiniaLotnicza.FindAsync(id);

            if (LiniaLotnicza != null)
            {
                _context.LiniaLotnicza.Remove(LiniaLotnicza);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
