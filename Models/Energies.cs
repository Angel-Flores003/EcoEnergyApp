using Microsoft.AspNetCore.Mvc;

namespace EcoEnergyApp.Models
{
    public class Energies : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}