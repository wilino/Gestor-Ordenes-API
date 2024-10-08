using System;
using Microsoft.AspNetCore.Mvc;
using GestorOrdenes.Servicios.Interfaces;
using GestorOrdenes.Servicios.DTOs;
using GestorOrdenes.Servicios.Excepciones;

namespace GestorOrdenes.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdenController : ControllerBase
    {
        private readonly IOrdenService _ordenService;

        public OrdenController(IOrdenService ordenService)
        {
            _ordenService = ordenService;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerOrdenPorId(int id)
        {
            try
            {
                var orden = await _ordenService.ObtenerPorId(id);
                return Ok(orden);
            }
            catch (OrdenNoEncontradaException ex)
            {
                return NotFound(ex.Message); // 404 Not Found
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}"); 
            }
        }


        [HttpPost]
        public async Task<IActionResult> CrearOrden([FromBody] CrearOrdenDto ordenDto)
        {
            try
            {
                await _ordenService.CrearOrden(ordenDto);
                return Ok("Orden creada exitosamente."); 
            }
            catch (ClienteNoEncontradoException ex)
            {
                return NotFound(ex.Message); 
            }
            catch (ProductoNoEncontradoException ex)
            {
                return NotFound(ex.Message);
            }
            catch (StockInsuficienteException ex)
            {
                return BadRequest(ex.Message); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}"); 
            }
        }
    }

}

