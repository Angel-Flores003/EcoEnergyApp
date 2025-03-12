namespace EcoEnergyApp.Models
{
    public class SistemaEolic : ASistemaEnergia, ICalculEnergia
    {
        public double VelocitatVent { get; set; }

        public SistemaEolic()
        {
            VelocitatVent = 5;
            EnergiaGenerada = CalculEnergia(VelocitatVent);
            EnergiaDate = DateTime.Now;
        }
        public SistemaEolic(double velocitatvent)
        {
            VelocitatVent = velocitatvent >= 5 ? velocitatvent : 5;
            EnergiaGenerada = CalculEnergia(VelocitatVent);
            EnergiaDate = DateTime.Now;
        }

        public double CalculEnergia(double velocitatvent)
        {
            EnergiaGenerada = Math.Pow(velocitatvent, 3) * 0.2;
            return EnergiaGenerada;
        }
    }
}