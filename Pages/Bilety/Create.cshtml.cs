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

            var selBagaz = _context.Bagaz.Select(c => new SelectListItem
            {
                Value = c.id_bagazu.ToString(),
                Text = c.id_bagazu.ToString() + " - " + c.waga.ToString() + "kg"
            });

            var selLot = _context.Lot.Select(c => new SelectListItem
            {
                Value = c.id_lotu.ToString(),
                Text = c.Lotnisko.lokalizacja.ToString().Substring(0,3) + " -> " + c.Lotnisko_Koncowe.lokalizacja.ToString().Substring(0, 3) + " Czas: " + c.data.ToString("dd.MM.yyyy HH:mm")
            });

            ViewData["id_bagazu"] = new SelectList(selBagaz, "Value", "Text");

            var selPas = _context.Pasazer.Select(c => new SelectListItem
            {
                Value = c.id_pasazera.ToString(),
                Text = c.id_pasazera.ToString() + " - " + c.imie.ToString() + " " + c.nazwisko.ToString()
            });

            //ViewData["id_bagazu"] = new SelectList(_context.Bagaz, "id_bagazu", "id_bagazu");
            ViewData["id_lotu"] = new SelectList(selLot, "Value", "Text");
            ViewData["id_pasazera"] = new SelectList(selPas, "Value", "Text");
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
