using DataInterfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Examen_dev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculosController : ControllerBase
    {
        protected readonly IVehiculosServices _vehiculosServices;

        public VehiculosController(IVehiculosServices vehiculosServices)
        {
            _vehiculosServices = vehiculosServices;
        }

        [HttpGet("GetVehiculos")]
        public async Task<IActionResult> GetVehiculos(int? filterType, string? nombre)
        {
            try
            {
                var result = await _vehiculosServices.ObtenerVehiculos(filterType, nombre);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Import")]
        public async Task<IActionResult> ImportData()
        {
            try
            {
                await _vehiculosServices.IImportData();
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
