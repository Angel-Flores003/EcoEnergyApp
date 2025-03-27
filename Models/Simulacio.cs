using System.ComponentModel.DataAnnotations;
using System.Runtime.ConstrainedExecution;

namespace EcoEnergyApp.Models
{
    //Seleccionar un tipo de energia
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

        //Gurada la hora a la que se ha añadido una fila
        public DateTime DataHora { get; set; } = DateTime.Now;

        //Para seleccionar que tipo de enrgia
        [Required(ErrorMessage = "El sistema d’energia és obligatori.")]
        public TipusSistema Sistema { get; set; }

        //Deberia cambiar entre solar, heolica e hidroelectrica
        public double EnergyType { get; set; }
        
        //Para añaadir el Rati
        [Range(0, 3, ErrorMessage = "El Rati ha de ser un valor entre 0 i 3")]
        public double Rati { get; set; }

        //Deberia calcular la energia generada en base al tipo de enrgia y el Rati
        public double EnergiaGenerada { get; set; }

        //Coste por KWh
        [Required(ErrorMessage = "El cost per kWh és obligatori")]
        [Range(0, 999999999, ErrorMessage = "El cost per kWh no pot contenir més de 999999999 caràcters.")]
        public double CostkWh { get; set; }

        //Precio del KWh
        [Required(ErrorMessage = "El preu per kWh és obligatori")]
        [Range(0, 999999999, ErrorMessage = "El preu per kWh no pot contenir més de 999999999 caràcters.")]
        public double PreukWh { get; set; }

        //Coste total
        public double CostTotal { get; set; }

        //Precio total
        public double PreuTotal { get; set; }
    }
}