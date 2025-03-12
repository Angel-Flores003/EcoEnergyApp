using EcoEnergyApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace gestioconsums.Pages
{
    public class AddConsumsModel : PageModel
    {
        [BindProperty]
        public Consum? Consum { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Consum?.Comarques?.ToString().Length > 8)
            {
                ModelState.AddModelError("Product.Comarques", "Les Comarques han de tenir com a màxim 8 xifres");
                return Page();
            }
            string filePath = "consum_aigua_cat_per_comarques.csv";
            string productLine = $"{Consum?.Comarques},{Consum?.Consumo}";

            System.IO.File.AppendAllText(filePath, productLine + Environment.NewLine);

            return RedirectToPage("Consums_Aigua");
        }
    }
}