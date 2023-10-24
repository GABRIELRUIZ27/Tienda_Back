using System;
using System.Collections.Generic;

namespace TIENDA.Models;

public partial class ArticuloTiendum
{
    public int? ArticuloId { get; set; }

    public int? TiendaId { get; set; }

    public DateTime? Fecha { get; set; }

    public virtual Artículo? Articulo { get; set; }

    public virtual Tiendum? Tienda { get; set; }
}
