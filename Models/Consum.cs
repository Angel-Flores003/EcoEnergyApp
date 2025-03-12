using System.ComponentModel.DataAnnotations;

namespace EcoEnergyApp.Models
{
    public class Consum
    {
        [Required(ErrorMessage = "El nom de la comarca és obligatori")]
        [StringLength(100, ErrorMessage = "El nom de la comarca no pot tenir més de 100 caràcters.")]
        public string? Comarques{ get; set; }

        [Required(ErrorMessage = "La quantitat del consum és obligatoria")]
        [Range(1, 9999999, ErrorMessage = "El consum ha de tenir 8 xifres com a màxim.")]
        public int Consumo { get; set; }
    }
}