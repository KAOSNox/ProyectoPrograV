using System;
using System.Collections.Generic;

namespace ProyectoProgra5.Models;

public partial class Rol
{
    public int IdRol { get; set; }

    public string Nombre { get; set; } = null!;

    public byte Accesso { get; set; }

    public virtual ICollection<UserxRol> UserxRols { get; set; } = new List<UserxRol>();
}
