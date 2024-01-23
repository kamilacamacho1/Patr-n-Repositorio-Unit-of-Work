namespace EFCoreRepositoryUnitofWork.Entities
{
    public class PruebaSeleccion
    {
        public int ID { get; set; }
        public string NombreDescripcion { get; set; }
        public int AspiranteID { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinalizacion { get; set; }
        public string TipoPrueba { get; set; }
        public string LenguajeProgramacion { get; set; }
        public int CantidadPreguntas { get; set; }
        public string Nivel { get; set; }
    }
}
