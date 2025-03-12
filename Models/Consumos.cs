using Microsoft.AspNetCore.Mvc;

namespace EcoEnergyApp.Models
{
    public class Consumos : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}