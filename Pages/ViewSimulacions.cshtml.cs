using EcoEnergyApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace gestiosimulacions.Pages
{
    public class ViewSimulacionsModel : PageModel
    {
        public List<Simulacio> Simulacio{ get; set; } = new List<Simulacio>();
        public void OnGet()
        {
            string filePath = "simulacions_energia.csv";
            if (System.IO.File.Exists(filePath))
            {
                var lines = System.IO.File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length == 8)
                    {
                        var simulacio = new Simulacio
                        {
                            ID = int.Parse(parts[0]),
                            Sistema = (TipusSistema)Enum.Parse(typeof(TipusSistema), parts[1]),
                            DataHora = parts[2],
                            Rati = double.Parse(parts[3]),
                            CostkWh = double.Parse(parts[4]),
                            PreukWh = double.Parse(parts[5]),
                            CostTotal = double.Parse(parts[6]),
                            PreuTotal = double.Parse(parts[7])
                        };
                        Simulacio.Add(simulacio);
                    }
                }
            }
        }
    }
}