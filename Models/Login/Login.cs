using System.ComponentModel.DataAnnotations;

namespace ProyectoProgra5.Models.Login
{
    public class Login
    {
        [Required(ErrorMessage ="Este campo es obligatorio")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DataType(DataType.Password)]
        public string Contraseña { get; set; }
        public bool Recordarme { get; set; }
    }
}
