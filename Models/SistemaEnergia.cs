namespace EcoEnergyApp.Models
{
    public abstract class ASistemaEnergia
    {
        protected double EnergiaGenerada { get; set; }
        public DateTime EnergiaDate { get; set; }
    }
}