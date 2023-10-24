using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TIENDA.Models;

namespace TIENDA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiendaController : ControllerBase
    {
        public readonly MasterContext _masterContext;

        public TiendaController(MasterContext masterContext)
        {
            _masterContext = masterContext;
        }

        [HttpGet]
        [Route("Get_Tienda")]
        public IActionResult GetArticulosTienda()
        {
            try
            {
                var tienda = _masterContext.Tienda.ToList();
                return Ok(tienda);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }
    }
}
