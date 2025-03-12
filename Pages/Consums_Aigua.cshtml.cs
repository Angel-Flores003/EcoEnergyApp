using EcoEnergyApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace gestioconsums.Pages
{
    public class Consums_AiguaModel : PageModel
    {
        public List<Consum> Consum { get; set; } = new List<Consum>();
        public void OnGet()
        {
            string filePath = "consum_aigua_cat_per_comarques.csv";
            if (System.IO.File.Exists(filePath))
            {
                var lines = System.IO.File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length == 2)
                    {
                        var consum = new Consum
                        {
                            Comarques = parts[0],
                            Consumo = int.Parse(parts[1])
                        };
                        Consum.Add(consum);
                    }
                }
            }
        }
    }
}