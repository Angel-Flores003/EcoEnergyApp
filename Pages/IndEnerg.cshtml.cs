using EcoEnergyApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace gestioenergia.Pages
{
    public class IndEnergModel : PageModel
    {
        public List<IndicadorsEnergetics> Energi { get; set; } = new List<IndicadorsEnergetics>();
        public void OnGet()
        {
            string filePath = "energia.csv";
            if (System.IO.File.Exists(filePath))
            {
                var lines = System.IO.File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length == 3)
                    {
                        var energia = new IndicadorsEnergetics
                        {
                            ID = int.Parse(parts[0]),
                            Name = parts[1],
                            Amount = int.Parse(parts[2])
                        };
                        Energi.Add(energia);
                    }
                }
            }
        }
    }
}
