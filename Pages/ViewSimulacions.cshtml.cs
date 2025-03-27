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
                    var parts = line.Split(',');//separa por comas 
                    if (parts.Length == 10)//Revisa que en total tenga 10 atributos
                    {
                        var simulacio = new Simulacio
                        {
                            ID = int.Parse(parts[0]),
                            DataHora = DateTime.Parse(parts[1]),
                            Sistema = (TipusSistema)Enum.Parse(typeof(TipusSistema), parts[2]),
                            EnergyType = double.Parse(parts[3]),
                            Rati = double.Parse(parts[4]),
                            EnergiaGenerada = double.Parse(parts[5]),
                            CostkWh = double.Parse(parts[6]),
                            PreukWh = double.Parse(parts[7]),
                            CostTotal = double.Parse(parts[8]),
                            PreuTotal = double.Parse(parts[9])
                        };
                        Simulacio.Add(simulacio); //Añade los parametros a "simulacio"
                    }
                }
            }
        }
    }
}