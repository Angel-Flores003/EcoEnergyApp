using System.ComponentModel.DataAnnotations;
using System.Runtime.ConstrainedExecution;

namespace EcoEnergyApp.Models
{
    public enum TipusSistema
    {
        Solar = 1,
        Eolic = 2,
        Hidroelectric = 3
    }

    public class Simulacio
    {
        [Required(ErrorMessage = "L'ID és obligatori")]
        [Range(1, 9999999, ErrorMessage = "L'ID ha de tenir 8 xifres com a màxim.")]
        public int ID { get; set; }

        [Required(ErrorMessage = "El sistema d’energia és obligatori.")]
        public TipusSistema Sistema { get; set; }

        [Required(ErrorMessage = "Les hores i la data són obligatories")]
        [StringLength(100, ErrorMessage = "Les hores i la data no pot tenir més de 100 caràcters.")]
        public string? DataHora { get; set; }

        [Range(0.00, 3.00, ErrorMessage = "El Rati ha de ser un valor entre 0 i 3")]
        public double Rati { get; set; }

        [Required(ErrorMessage = "El cost per kWh és obligatori")]
        [Range(0, 999999999, ErrorMessage = "El cost per kWh no pot contenir més de 999999999 caràcters.")]
        public double CostkWh { get; set; }

        [Required(ErrorMessage = "El preu per kWh és obligatori")]
        [Range(0, 999999999, ErrorMessage = "El preu per kWh no pot contenir més de 999999999 caràcters.")]
        public double PreukWh { get; set; }

        [Required(ErrorMessage = "El preu per kWh és obligatori")]
        [Range(0, 999999999, ErrorMessage = "El preu per kWh no pot contenir més de 999999999 caràcters.")]
        public double CostTotal { get; set; }

        [Required(ErrorMessage = "El preu per kWh és obligatori")]
        [Range(0, 999999999, ErrorMessage = "El preu per kWh no pot contenir més de 999999999 caràcters.")]
        public double PreuTotal { get; set; }
    }
}
