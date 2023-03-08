namespace webApi.Data
{
    public class Pecera
    {
        public int PeceraID { get; set; }
        public string Nombre_Pecera { get; set; }
        public int Capacidad_Peces { get; set; }
        public int Capacidad_LitrosAgua { get; set; }
        public int AcuarioID { get; set; }
        public Acuario Acuario { get; set; }

    }
}
