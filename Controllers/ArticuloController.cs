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
    public class ArticuloController : ControllerBase
    {
        private readonly MasterContext _masterContext;

        public ArticuloController(MasterContext masterContext)
        {
            _masterContext = masterContext;
        }

        [HttpGet]
        [Route("Get_Articulo")]
        public IActionResult GetArticulos()
        {
            try
            {
                List<Artículo> articulos = _masterContext.Artículos.ToList();
                return Ok(articulos); 
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }
    }
}
