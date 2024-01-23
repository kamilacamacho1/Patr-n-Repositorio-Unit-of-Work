namespace WebApplication.Models
{
    public class Aspirante
    {
        public int ID { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string DatosDeContacto { get; set; }

        public string EstadoPrueba { get; set; }

        public decimal? ResultadoPrueba { get; set; }
    }
}
