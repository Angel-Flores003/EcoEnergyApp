using EcoEnergyApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace gestiosimulacions.Pages
{
    public class AddSimulacioModel : PageModel
    {
        [BindProperty]
        public Simulacio? Simulacio { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Simulacio?.ID.ToString().Length > 8)
            {
                ModelState.AddModelError("Simulacio.ID", "L'ID ha de tenir com a màxim 8 xifres");
                return Page();
            }
            string filePath = "simulacions_energia.csv";
            string productLine = $"{Simulacio?.ID},{Simulacio?.Sistema},{Simulacio?.DataHora}," +
                $"{Simulacio?.Rati},{Simulacio?.CostkWh},{Simulacio?.PreukWh},{Simulacio?.CostTotal},{Simulacio?.PreuTotal}";

            System.IO.File.AppendAllText(filePath, productLine + Environment.NewLine);

            return RedirectToPage("ViewSimulacions");
        }
    }
}