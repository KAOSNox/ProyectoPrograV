using System;
using System.Collections.Generic;

namespace ProyectoProgra5.Models;

public partial class Eleccione
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public DateTime Fecha { get; set; }

    public string Descripcion { get; set; } = null!;
}
