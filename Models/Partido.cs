using System;
using System.Collections.Generic;

namespace ProyectoProgra5.Models;

public partial class Partido
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public DateTime Fundacion { get; set; }

    public string Lider { get; set; } = null!;
}
