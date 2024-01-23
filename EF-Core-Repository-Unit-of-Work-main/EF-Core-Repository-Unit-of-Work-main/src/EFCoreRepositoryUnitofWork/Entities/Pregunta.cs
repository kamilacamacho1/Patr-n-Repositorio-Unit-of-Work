namespace EFCoreRepositoryUnitofWork.Entities
{
    public class Pregunta
    {
        public int ID { get; set; }
        public int PruebaSeleccionID { get; set; }
        public string TextoPregunta { get; set; }
        public string OpcionesRespuesta { get; set; }
        public string RespuestaCorrecta { get; set; }
    }
}
