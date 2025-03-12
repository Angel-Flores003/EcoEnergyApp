using Microsoft.AspNetCore.Mvc;

namespace EcoEnergyApp.Models
{
    public class Simulacions : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}