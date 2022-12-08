using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SBD.Data;
using SBD.Models;

namespace SBD.Pages.Licencje
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

            var selBag = _context.Pilot.Select(c => new SelectListItem
        {
            Value = c.id_pilota.ToString(),
            Text = c.id_pilota.ToString() + " - " + c.imie.ToString() +" " + c.nazwisko.ToString()
            });
            ViewData["id_pilota"] = new SelectList(selBag, "Value", "Text");
            return Page();
        }

        [BindProperty]
        public Licencja Licencja { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Licencja.Add(Licencja);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
