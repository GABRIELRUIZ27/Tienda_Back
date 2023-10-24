using System;
using System.Collections.Generic;

namespace TIENDA.Models;

public partial class Artículo
{
    public int Codigo { get; set; }

    public string Descripcion { get; set; } = null!;

    public decimal Precio { get; set; }

    public string? Imagen { get; set; }

    public int Stock { get; set; }
}
