using System;
using System.Collections.Generic;

namespace ProyectoProgra5.Models;

public partial class Cargo
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;
}
