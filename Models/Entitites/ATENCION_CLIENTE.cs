using System.ComponentModel.DataAnnotations;

namespace WebAtencionClientes.Models.Entitites
{
    public class ATENCION_CLIENTE
    {
        public int Id { get; set; }
        [Display(Name = "Nombre")]
        public string NOMBRE { get; set; }
        [Display(Name = "Apellidos")]
        public string APELLIDOS { get; set; }
        [Display(Name = "Nombre")]
        public string CELULAR { get; set; }
        [Display(Name = "Nombre")]
        public string EMAIL { get; set; }
        [Display(Name = "Nombre")]
        public string SEXO { get; set; }
        [Display(Name = "Nombre")]
        public string MOTIVO { get; set; }
        [Display(Name = "Nombre")]
        public DateTime FECHA_ALTA { get; set; }
    }
}
