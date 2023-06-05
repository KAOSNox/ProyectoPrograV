using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProyectoProgra5.Models;

public partial class Candidato
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Este campo es obligatorio.")]
    public string Nombre { get; set; } = null!;
    [Required(ErrorMessage = "Este campo es obligatorio.")]
    public string Partido { get; set; } = null!;
    [Required(ErrorMessage = "Este campo es obligatorio.")]
    public string Cargo { get; set; } = null!;
    [Required(ErrorMessage = "Este campo es obligatorio.")]
    public string Experencia { get; set; } = null!;
    

}
