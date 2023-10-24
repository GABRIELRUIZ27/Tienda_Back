using System;
using System.Collections.Generic;

namespace TIENDA.Models;

public partial class Tiendum
{
    public int TiendaId { get; set; }

    public string Sucursal { get; set; } = null!;

    public string Direccion { get; set; } = null!;
}
