using Example.Models;
using Consums.Models;
using Indicadors.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EcoEnergyApp2.Data
{
    public class EnergiDbContext : DbContext
    {
        public DbSet<Simulacions> Simulacions { get; set; }
        public DbSet<ConsumsAigua> ConsumsAigua { get; set; }
        public DbSet<IndicadorsEnergetics> IndicadorsEnergetics { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connectionString = configuration.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);
        }
    }
}