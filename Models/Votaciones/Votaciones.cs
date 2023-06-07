using System.ComponentModel.DataAnnotations;

namespace ProyectoProgra5.Models.Votaciones
{
    public class Votaciones
    {
        public int Id { get; set; }

        public string Elecciones { get; set; }

        public string Partido { get; set; }

        public string Mesa { get; set; } = null!;

        public int Votos { get; set; }  
    }

    public class VotacionesCreate
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Este campo es obligatorio.")]
        public int Elecciones { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public int Partido { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public string Mesa { get; set; } = null!;

        [Required(ErrorMessage = "Este campo es obligatorio.")]
        public int Votos { get; set; }

        public List<Eleccione> eleccionesList { get; set; }
        public List<Partido> partidosList { get; set; } 
    }
}
