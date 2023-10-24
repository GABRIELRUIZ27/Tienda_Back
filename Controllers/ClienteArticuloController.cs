using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TIENDA.Models;

namespace TIENDA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteArticuloController : ControllerBase
    {
        private readonly MasterContext _masterContext;

        public ClienteArticuloController(MasterContext masterContext)
        {
            _masterContext = masterContext;
        }

        [HttpGet]
        [Route("Get_ClienteArticulo")]
        public IActionResult GetClienteArticulos()
        {
            try
            {
                List<ClienteArticulo> clienteArticulos = _masterContext.ClienteArticulos.ToList();
                return Ok(clienteArticulos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

        [HttpPost]
        [Route("Post_ClienteArticulo")]
        public IActionResult PostClienteArticulo([FromBody] ClienteArticulo clienteArticulo)
        {
            try
            {
                if (clienteArticulo != null)
                {
                    _masterContext.ClienteArticulos.Add(clienteArticulo);
                    _masterContext.SaveChanges();
                    return StatusCode(StatusCodes.Status201Created);
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new { mensaje = "Los datos no son válidos." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

        [HttpDelete("Delete_ClienteArticulo/{id}")]
        public IActionResult DeleteClienteArticulo(int id)
        {
            try
            {
                var clienteArticulo = _masterContext.ClienteArticulos.Find(id);

                if (clienteArticulo == null)
                {
                    return NotFound(new { mensaje = "No se encontró el clienteArticulo con el ID proporcionado." });
                }

                _masterContext.ClienteArticulos.Remove(clienteArticulo);
                _masterContext.SaveChanges();

                return Ok(); 
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

    }
}
