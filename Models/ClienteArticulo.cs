using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TIENDA.Models;

public partial class ClienteArticulo
{
  
    public int? Id { get; set; }

    public int? ClienteId { get; set; }

    public int? ArticuloId { get; set; }

    public DateTime? Fecha { get; set; }

}
