using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SBD.Data;
using SBD.Models;

namespace SBD.Pages.Lotniska
{
    public class DeleteModel : PageModel
    {
        private readonly SBD.Data.AirPortContext _context;

        public DeleteModel(SBD.Data.AirPortContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Lotnisko Lotnisko { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Lotnisko = await _context.Lotnisko.FirstOrDefaultAsync(m => m.id_lotniska == id);

            if (Lotnisko == null)
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

            Lotnisko = await _context.Lotnisko.FindAsync(id);

            if (Lotnisko != null)
            {
                _context.Lotnisko.Remove(Lotnisko);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
