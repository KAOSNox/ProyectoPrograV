using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProyectoProgra5.Models;

public partial class Partido
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Este campo es obligatorio.")]
    public string Nombre { get; set; } = null!;

    [DataType(DataType.Date)]
    public DateTime Fundacion { get; set; }
    [Required(ErrorMessage = "Este campo es obligatorio.")]
    public string Lider { get; set; } = null!;
   


}
