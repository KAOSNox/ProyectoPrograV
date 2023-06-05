using System;
using System.Collections.Generic;

namespace ProyectoProgra5.Models;

public partial class Candidato
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Partido { get; set; } = null!;

    public string Cargo { get; set; } = null!;

    public string Experencia { get; set; } = null!;

    public virtual ICollection<Votacion> Votacions { get; set; } = new List<Votacion>();
}
