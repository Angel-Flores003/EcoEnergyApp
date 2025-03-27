using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Example.Models
{
    [Table("Simulacions")]
    public class Simulacions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Type { get; set; }
        public int HoresSol { get; set; }
        public int VelocitatVent { get; set; }
        public int CabalAigua { get; set; }
        public int Rati{ get; set; }
        public int EnergiaGenerada { get; set; }
        public int CostKWh { get; set; }
        public int PreuKWh { get; set; }
        public DateTime DataHora { get; set; }
    }
}