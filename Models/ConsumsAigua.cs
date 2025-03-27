using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Consums.Models
{
    [Table("ConsumsAigua")]
    public class ConsumsAigua
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Comaraca { get; set; }
        public string? Municipi{ get; set; }
        public int Any { get; set; }
        public int Consum { get; set; }
    }
}