using EcoEnergyApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace gestioenergia.Pages
{
    public class AddEnergModel : PageModel
    {
        [BindProperty]
        public IndicadorEnergetic? Energi { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Energi?.ID.ToString().Length > 8)
            {
                ModelState.AddModelError("Energi.ID", "L'ID ha de tenir com a màxim 8 xifres");
                return Page();
            }
            string filePath = "energia.csv";
            string productLine = $"{Energi?.ID}, {Energi?.Name}, {Energi?.Amount}";

            System.IO.File.AppendAllText(filePath, productLine + Environment.NewLine);

            return RedirectToPage("IndEnerg");
        }
    }
}
