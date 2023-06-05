using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProyectoProgra5.Models;

public partial class Cargo
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Este campo es obligatorio.")]
    public string Nombre { get; set; } = null!;
    [Required(ErrorMessage = "Este campo es obligatorio.")]
    public string Descripcion { get; set; } = null!;
    
}
