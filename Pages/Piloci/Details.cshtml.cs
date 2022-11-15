using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SBD.Data;
using SBD.Models;

namespace SBD.Pages.Piloci
{
    public class DetailsModel : PageModel
    {
        private readonly SBD.Data.AirPortContext _context;

        public DetailsModel(SBD.Data.AirPortContext context)
        {
            _context = context;
        }

        public Pilot Pilot { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pilot = await _context.Pilot.FirstOrDefaultAsync(m => m.id_pilota == id);

            if (Pilot == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
