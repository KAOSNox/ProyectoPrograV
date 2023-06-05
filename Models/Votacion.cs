using System;
using System.Collections.Generic;

namespace ProyectoProgra5.Models;

public partial class Votacion
{
    public int IdVotacion { get; set; }

    public int IdUsuario { get; set; }

    public int IdCandidato { get; set; }

    public virtual Candidato IdCandidatoNavigation { get; set; } = null!;

    public virtual User IdUsuarioNavigation { get; set; } = null!;
}
