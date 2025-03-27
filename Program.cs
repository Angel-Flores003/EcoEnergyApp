using EcoEnergyApp2.Data;
using Example.Models;
using Consums.Models;
using Indicadors.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;
using EcoEnergyApp.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace efexample
{
    public class Program
    {
        public static void Main()
        {
            using var context = new EnergiDbContext();

            // Crear una nueva Simulación
            var simulacio = new Simulacions 
            { 
                Type = "Barcelona", 
                HoresSol = 8, 
                VelocitatVent = 12, 
                CabalAigua = 21, 
                Rati = 3,
                CostKWh = 1, 
                PreuKWh = 2, 
                EnergiaGenerada = 12, 
                DataHora = DateTime.Parse("2025-03-18 00:00:00") //DateTime.Now
            };
            context.Simulacions.Add(simulacio);
            context.SaveChanges(); // Aquí es guarda la simulació i se li assigna un Id

            //Crear un nuevo consumo i li assignem l'Id de la simulació
            var consum = new ConsumsAigua 
            { 
                Comaraca = "Irlanda", 
                Municipi = "Dublin", 
                Any = 3143, 
                Consum = 12,
            };
            context.ConsumsAigua.Add(consum);
            context.SaveChanges(); // Aquí es guarden els consums d'aigua

            //Crear un indicador energetic i li assignem l'Id de la simulació
            var indicador = new IndicadorsEnergetics
            {
                Any = 2031,
                ProduccioNeta = 3,
                ConsumGasolina = 12,
                DemandaElectrica = 12,
                ProduccioDisponible = 4,
            };
            context.IndicadorsEnergetics.Add(indicador);
            context.SaveChanges();


            // Modificar una simulació
            var simulacioToUpdate = context.Simulacions.Find(simulacio.Id);
            if (simulacioToUpdate != null)
            {
                simulacioToUpdate.Type = "";
                simulacioToUpdate.HoresSol = 8;
                simulacioToUpdate.VelocitatVent = 12;
                simulacioToUpdate.CabalAigua = 21;
                simulacioToUpdate.Rati = 3;
                simulacioToUpdate.CostKWh = 1; 
                simulacioToUpdate.PreuKWh = 2;
                simulacioToUpdate.EnergiaGenerada = 12;
                simulacioToUpdate.DataHora = DateTime.Parse("2025-03-18 00:00:00");
                context.SaveChanges();
            }

            // Modificar el consum d'aigua
            var consumToUpdate = context.ConsumsAigua.Find(consum.Id);
            if (consumToUpdate != null)
            {
                consumToUpdate.Comaraca = ""; 
                consumToUpdate.Municipi = "";
                consumToUpdate.Any = 1298;
                consumToUpdate.Consum = 12;
                context.SaveChanges();
            }

            // Modificar els indicadors d'energia
            var indicadorToUpdate = context.IndicadorsEnergetics.Find(indicador.Id);
            if (indicadorToUpdate != null)
            {
                indicadorToUpdate.Any = 2020;
                indicadorToUpdate.ProduccioNeta = 3;
                indicadorToUpdate.ConsumGasolina = 12;
                indicadorToUpdate.DemandaElectrica = 12;
                indicadorToUpdate.ProduccioDisponible = 4;
                context.SaveChanges();
            }


            // Eliminar una simulació
            var simulacioToDelete = context.Simulacions.Find(simulacio.Id);
            if (simulacioToDelete != null)
            {
                context.Simulacions.Remove(simulacioToDelete);
                context.SaveChanges();
            }

            // Eliminar una simulació
            var consumToDelete = context.ConsumsAigua.Find(consum.Id);
            if (consumToDelete != null)
            {
                context.ConsumsAigua.Remove(consumToDelete);
                context.SaveChanges();
            }

            // Eliminar una simulació
            var indicadorToDelete = context.IndicadorsEnergetics.Find(indicador.Id);
            if (indicadorToDelete != null)
            {
                context.IndicadorsEnergetics.Remove(indicadorToDelete);
                context.SaveChanges();
            }


            // Obtenir una simulació per Id
            var simulacioId = 1;
            var simulacioById = context.Simulacions.Find(simulacioId);
            if (simulacioById != null)
            {
                Console.WriteLine($"Simulació trobada:\n" +
                    $"ID:{simulacioById.Id}\n" +
                    $"Nom: {simulacioById.Type}\n" +
                    $"Cognoms: {simulacioById.HoresSol}\n" +
                    $"Velocitat del Vent: {simulacioById.VelocitatVent}\n" +
                    $"Cabal d'Aigua: {simulacioById.CabalAigua}\n" +
                    $"Rati: {simulacioById.Rati}\n" +
                    $"Energia Generada: {simulacioById.EnergiaGenerada}\n" +
                    $"Cost KWh: {simulacioById.CostKWh}\n" +
                    $"Preu KWh: {simulacioById.PreuKWh}\n" +
                    $"Data i Hora: {simulacioById.DataHora}");
            }
            else
            {
                Console.WriteLine($"No s'ha trobat cap simulació amb l'ID {simulacioId}");
            }

            // Obtenir una simulació per Id
            var consumId = 1;
            var consumById = context.ConsumsAigua.Find(consumId);
            if (consumById != null)
            {
                Console.WriteLine($"Consum d'aigua trobat:\n" +
                    $"ID:{consumById.Id}\n" +
                    $"Nom: {consumById.Comaraca}\n" +
                    $"Cognoms: {consumById.Municipi}\n" +
                    $"Velocitat del Vent: {consumById.Any}\n" +
                    $"Cabal d'Aigua: {consumById.Consum}");
            }
            else
            {
                Console.WriteLine($"No s'ha trobat cap consum d'aigua amb l'ID {consumId}");
            }

            // Obtenir una simulació per Id
            var indicadorId = 1;
            var indicadorById = context.IndicadorsEnergetics.Find(indicadorId);
            if (indicadorById != null)
            {
                Console.WriteLine($"Indicador energètic trobat:\n" +
                    $"ID:{indicadorById.Id}\n" +
                    $"Nom: {indicadorById.Any}\n" +
                    $"Cognoms: {indicadorById.ProduccioNeta}\n" +
                    $"Velocitat del Vent: {indicadorById.ConsumGasolina}\n" +
                    $"Cabal d'Aigua: {indicadorById.DemandaElectrica}\n" +
                    $"Rati: {indicadorById.ProduccioDisponible}");
            }
            else
            {
                Console.WriteLine($"No s'ha trobat cap Indicador energètic amb l'ID {indicadorId}");
            }


            // Mostrar la llsita de simulacions
            var simulacions = context.Simulacions.ToList();
            foreach (var simulacion in simulacions)
            {
                Console.WriteLine($"Simulació trobada:\n" +
                    $"ID:{simulacion.Id}\n" +
                    $"Nom: {simulacion.Type}\n" +
                    $"Cognoms: {simulacion.HoresSol}\n" +
                    $"Velocitat del Vent: {simulacion.VelocitatVent}\n" +
                    $"Cabal d'Aigua: {simulacion.CabalAigua}\n" +
                    $"Rati: {simulacion.Rati}\n" +
                    $"Energia Generada: {simulacion.EnergiaGenerada}\n" +
                    $"Cost KWh: {simulacion.CostKWh}\n" +
                    $"Preu KWh: {simulacion.PreuKWh}\n" +
                    $"Data i Hora: {simulacion.DataHora}");
            }
            // Mostrar la llsita de simulacions
            Console.WriteLine("***** Versió amb ForEach *********");
            context.Simulacions.ToList().ForEach(s =>
            Console.WriteLine($"Simulació trobada:\n" +
                    $"ID:{s.Id}\n" +
                    $"Nom: {s.Type}\n" +
                    $"Cognoms: {s.HoresSol}\n" +
                    $"Velocitat del Vent: {s.VelocitatVent}\n" +
                    $"Cabal d'Aigua: {s.CabalAigua}\n" +
                    $"Rati: {s.Rati}\n" +
                    $"Energia Generada: {s.EnergiaGenerada}\n" +
                    $"Cost KWh: {s.CostKWh}\n" +
                    $"Preu KWh: {s.PreuKWh}\n" +
                    $"Data i Hora: {s.DataHora}")
            );

            // Mostrar la llsita de consum d'aigua
            var consums = context.ConsumsAigua.ToList();
            foreach (var consumo in consums)
            {
                Console.WriteLine($"Consum d'aigua trobat:\n" +
                    $"ID:{consumo.Id}\n" +
                    $"Nom: {consumo.Comaraca}\n" +
                    $"Cognoms: {consumo.Municipi}\n" +
                    $"Velocitat del Vent: {consumo.Any}\n" +
                    $"Cabal d'Aigua: {consumo.Consum}");
            }
            // Mostrar la llsita de consum d'aigua
            Console.WriteLine("***** Versió amb ForEach *********");
            context.ConsumsAigua.ToList().ForEach(c =>
            Console.WriteLine($"Consum d'aigua trobat:\n" +
                    $"ID:{c.Id}\n" +
                    $"Nom: {c.Comaraca}\n" +
                    $"Cognoms: {c.Municipi}\n" +
                    $"Velocitat del Vent: {c.Any}\n" +
                    $"Cabal d'Aigua: {c.Consum}")
            );

            // Mostrar la llsita d'indicador energètics
            var indicadors = context.IndicadorsEnergetics.ToList();
            foreach (var indicadores in indicadors)
            {
                Console.WriteLine($"Indicador energètic trobat:\n" +
                    $"ID:{indicadores.Id}\n" +
                    $"Nom: {indicadores.Any}\n" +
                    $"Cognoms: {indicadores.ProduccioNeta}\n" +
                    $"Velocitat del Vent: {indicadores.ConsumGasolina}\n" +
                    $"Cabal d'Aigua: {indicadores.DemandaElectrica}\n" +
                    $"Rati: {indicadores.ProduccioDisponible}");
            }
            // Mostrar la llsita d'indicador energètics
            Console.WriteLine("***** Versió amb ForEach *********");
            context.IndicadorsEnergetics.ToList().ForEach(i =>
            Console.WriteLine($"Indicador energètic trobat:\n" +
                    $"ID:{i.Id}\n" +
                    $"Nom: {i.Any}\n" +
                    $"Cognoms: {i.ProduccioNeta}\n" +
                    $"Velocitat del Vent: {i.ConsumGasolina}\n" +
                    $"Cabal d'Aigua: {i.DemandaElectrica}\n" +
                    $"Rati: {i.ProduccioDisponible}")
            );
        }
    }
}



//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddRazorPages();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();

//app.UseRouting();

//app.UseAuthorization();

//app.MapStaticAssets();
//app.MapRazorPages()
//   .WithStaticAssets();

//app.Run();