namespace EcoEnergyApp.Models
{
    public class SistemaHidroelectric : ASistemaEnergia, ICalculEnergia
    {
        public double CabalAigua { get; set; }

        public SistemaHidroelectric()
        {
            CabalAigua = 20;
            EnergiaGenerada = CalculEnergia(CabalAigua);
            EnergiaDate = DateTime.Now;
        }

        public SistemaHidroelectric(double cabalaigua)
        {
            CabalAigua = cabalaigua >= 20 ? cabalaigua : 20;
            EnergiaGenerada = CalculEnergia(CabalAigua);
            EnergiaDate = DateTime.Now;
        }

        public double CalculEnergia(double cabalaigua)
        {
            EnergiaGenerada = cabalaigua * 9.8 * 0.8;
            return EnergiaGenerada;
        }
    }
}