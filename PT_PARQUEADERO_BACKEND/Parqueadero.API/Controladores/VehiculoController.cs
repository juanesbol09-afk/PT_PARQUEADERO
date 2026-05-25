using Microsoft.AspNetCore.Mvc;
using Parqueadero.Aplicacion.DTOs;
using Parqueadero.Aplicacion.Servicios;

namespace Parqueadero.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiculoController : ControllerBase
    {
        private readonly IVehiculoService _service;

        public VehiculoController(IVehiculoService service)
        {
            _service = service;
        }

        // GET: api/vehiculo/activos
        [HttpGet("activos")]
        public async Task<IActionResult> GetActivos()
        {
            var vehiculos = await _service.GetVehiculosActivosAsync();

            return Ok(vehiculos);
        }

        // POST: api/vehiculo/ingreso
        [HttpPost("ingreso")]
        public async Task<IActionResult> RegistrarIngreso(
            [FromBody] EntradaVehiculoDTO dto)
        {
            try
            {
                var vehiculo = await _service.RegistrarIngresoAsync(dto);

                return Ok(vehiculo);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensaje = ex.Message
                });
            }
        }

        // POST: api/vehiculo/salida/ABC123
        [HttpPost("salida/{placa}")]
        public async Task<IActionResult> RegistrarSalida(string placa)
        {
            try
            {
                var resultado = await _service.RegistrarSalidaAsync(placa);

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensaje = ex.Message
                });
            }
        }
    }
}