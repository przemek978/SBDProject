using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SBD.Data;
using SBD.Models;

namespace SBD.Pages.Piloci
{
    public class CreateModel : PageModel
    {
        private readonly SBD.Data.AirPortContext _context;

        public CreateModel(SBD.Data.AirPortContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["kod_linii"] = new SelectList(_context.LiniaLotnicza, "kod", "kod");
            return Page();
        }

        [BindProperty]
        public Pilot Pilot { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var passwordHasher = new PasswordHasher<string>();
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Pilot.haslo=passwordHasher.HashPassword(null, Pilot.haslo);
            _context.Pilot.Add(Pilot);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
