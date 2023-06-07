using System;
using System.Collections.Generic;

namespace ProyectoProgra5.Models;

public partial class Votacione
{
    public int Id { get; set; }

    public int IdElecciones { get; set; }

    public int IdPartido { get; set; }

    public string Mesa { get; set; } = null!;

    public int? Votos { get; set; }
}
