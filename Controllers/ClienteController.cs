using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


using Microsoft.EntityFrameworkCore;
using TIENDA.Models;


namespace TIENDA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        public readonly MasterContext _masterContext;

        public ClienteController(MasterContext masterContext)
        {
            _masterContext = masterContext;
        }

        [HttpGet]
        [Route("Cliente")]

        public IActionResult Lista()
        {
            List<Cliente> lista = new List<Cliente>();

            try
            {
                lista = _masterContext.Clientes.ToList();

                return StatusCode(StatusCodes.Status200OK, new {lista});
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });
            }
        }
    }
}
