using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SBD.Data;
using SBD.Models;

namespace SBD.Pages.Bilety
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
            ViewData["id_bagazu"] = new SelectList(_context.Bagaz, "id_bagazu", "id_bagazu");
            ViewData["id_lotu"] = new SelectList(_context.Lot, "id_lotu", "id_lotu");
            ViewData["id_pasazera"] = new SelectList(_context.Pasazer, "id_pasazera", "id_pasazera");
            return Page();
        }

        [BindProperty]
        public Bilet Bilet { get; set; }
        public string temp_miejsce { get; set; }
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }


            //bool if_correct = Bilet.przydziel_miejsce(int.Parse(temp_miejsce));
                
            //if (!if_correct)
            //{
            //    return Page();
            //}

            

            _context.Bilet.Add(Bilet);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
