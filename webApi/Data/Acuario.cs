namespace webApi.Data
{
    public class Acuario
    {
        public int AcuarioID { get; set; }

        public string Nombre_Acuario { get; set; }

        public string ubicacion { get; set; }

        public int maximo_visitantes { get; set; }

        public List<Pecera> Peceras { get; set; }
    }
}
