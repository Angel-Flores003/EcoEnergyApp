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
            //que el Id no tenga más de 8 digitos
            if (Simulacio?.ID.ToString().Length > 8)
            {
                ModelState.AddModelError("Simulacio.ID", "L'ID ha de tenir com a màxim 8 xifres");
                return Page();
            }
            string filePath = "simulacions_energia.csv"; //Lo añade en el csv
            string productLine = $"{Simulacio?.ID},{Simulacio?.DataHora},{Simulacio?.Sistema},{Simulacio?.EnergyType},{Simulacio?.Rati}," +
                $"{Simulacio?.EnergiaGenerada},{Simulacio?.CostkWh},{Simulacio?.PreukWh},{Simulacio?.CostTotal},{Simulacio?.PreuTotal}";
            //Todos los atributos
            System.IO.File.AppendAllText(filePath, productLine + Environment.NewLine);

            return RedirectToPage("ViewSimulacions"); //Vuelve a la pagina de Simulaciones
        }
    }
}