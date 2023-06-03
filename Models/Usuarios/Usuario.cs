using System.ComponentModel.DataAnnotations;

namespace ProyectoProgra5.Models.Usuarios
{
    public class Usuario
    {
        public int UserID { get; set; }

        [Required(ErrorMessage ="Este campo es obligatorio.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string Contraseña { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public int rolID { get; set; }
    }
}
