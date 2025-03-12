namespace EcoEnergyApp.Models
{
    public class SistemaSolar : ASistemaEnergia, ICalculEnergia
    {
        public double HoresSol { get; set; }

        public SistemaSolar()
        {
            HoresSol = 1.1;
            EnergiaGenerada = CalculEnergia(HoresSol);
            EnergiaDate = DateTime.Now;
        }

        public SistemaSolar(double hores_Sol)
        {
            hores_Sol = hores_Sol > 1 ? hores_Sol : 1.1;
            EnergiaGenerada = CalculEnergia(HoresSol);
            EnergiaDate = DateTime.Now;
        }

        public double CalculEnergia(double hores_Sol)
        {
            EnergiaGenerada = hores_Sol * 1.5;
            return EnergiaGenerada;
        }
    }
}