using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using TIENDA.Models;

namespace TIENDA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class articuloTiendaController : ControllerBase
    {
        public readonly MasterContext _masterContext;

        public articuloTiendaController(MasterContext masterContext)
        {
            _masterContext = masterContext;
        }

        [HttpGet]
        [Route("Get_TiendaArticulo")]
        public IActionResult GetArticulosTienda()
        {
            try
            {
                var articulosTienda = _masterContext.ArticuloTienda.ToList();
                return Ok(articulosTienda);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

    }
}
