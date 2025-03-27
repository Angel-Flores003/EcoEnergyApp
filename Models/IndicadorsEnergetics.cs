using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Indicadors.Models
{
    [Table("IndicadorsEnergetics")]
    public class IndicadorsEnergetics
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Any { get; set; }
        public int ProduccioNeta { get; set; }
        public int ConsumGasolina { get; set; }
        public int DemandaElectrica { get; set; }
        public int ProduccioDisponible { get; set; }
    }
}