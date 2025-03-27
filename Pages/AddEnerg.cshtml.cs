using EcoEnergyApp.Models;
using Indicadors.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace gestioenergia.Pages
{
    public class AddEnergModel : PageModel
    {
        [BindProperty]
        public IndicadorsEnergetics Energi { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            string filePath = "energia.csv";
            string productLine = $"{Energi?.Id}, {Energi?.Any}, {Energi?.ProduccioNeta}, " +
                $"{Energi?.ConsumGasolina}, {Energi?.DemandaElectrica}, {Energi?.ProduccioDisponible}";

            System.IO.File.AppendAllText(filePath, productLine + Environment.NewLine);

            return RedirectToPage("IndEnerg");
        }
    }
}
