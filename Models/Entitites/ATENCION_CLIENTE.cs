namespace WebAtencionClientes.Models.Entitites
{
    public class ATENCION_CLIENTE
    {
        public int Id { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDOS { get; set; }
        public string CELULAR { get; set; }
        public string EMAIL { get; set; }
        public string SEXO { get; set; }
        public string MOTIVO { get; set; }
        public DateTime FECHA_ALTA { get; set; }
    }
}
