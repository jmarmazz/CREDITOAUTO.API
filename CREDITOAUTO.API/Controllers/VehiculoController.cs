
using CREDITOAUTO.API.DataContracts;
using CREDITOAUTO.API.Extensions;
using CREDITOAUTO.APPLICATION.Interfaces.AppServices;
using CREDITOAUTO.DOMAIN.Constants;
using CREDITOAUTO.QUERY.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CREDITOAUTO.API.Controllers
{
    [ApiController]
    [Route("/Vehiculo")]
    public class VehiculoController : ControllerBase
    {
        private readonly IVehiculoAppService vehiculoAppService;

        public VehiculoController(IVehiculoAppService vehiculoAppService)
        {
            this.vehiculoAppService = vehiculoAppService;
        }

        [HttpGet]
        public List<VehiculoQueryDto> Consultar()
        {
            try
            {
                var result = vehiculoAppService.ConsultarVehiculos();
                if (result == null) { throw new Exception(null); }
                Response.StatusCode = StatusCodes.Status200OK;
                return result;
            }
            catch (Exception ex)
            {
                Response.StatusCode = StatusCodes.Status500InternalServerError;
                return null;
            }
        }

        [HttpPost]
        public IActionResult Crear(Vehiculo vehiculo)
        {
            string mensaje = "";
            bool result = false;
            try
            {
                var Vehiculodto = vehiculo.MapToVehiculoAppDto();
                result = vehiculoAppService.CrearVehiculo(ref Vehiculodto, ref mensaje);
                if (!result) return new ObjectResult(mensaje) { StatusCode = DomainConstants.ObtenerHttpStatusCode(mensaje.Substring(0, 3)) };

                return StatusCode(StatusCodes.Status200OK, "Registro ingresado correctamente");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error interno, por favor vuelva a intentar");
            }
        }

        [HttpPut]
        public IActionResult Actualizar(Vehiculo vehiculo)
        {
            string mensaje = "";
            bool result = false;
            try
            { 
                var Vehiculodto = vehiculo.MapToVehiculoAppDto();
                result = vehiculoAppService.ActualizarVehiculo(ref Vehiculodto, ref mensaje);
                if (!result) return new ObjectResult(mensaje) { StatusCode = DomainConstants.ObtenerHttpStatusCode(mensaje.Substring(0, 3)) };

                return StatusCode(StatusCodes.Status200OK, "Registro actualizado correctamente");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error interno, por favor vuelva a intentar");
            }
        }

        [HttpDelete]
        public IActionResult Eliminar(int idVehiculo)
        {
            string mensaje = "";
            bool result = false;
            try
            { 
                result = vehiculoAppService.EliminarVehiculo(idVehiculo, ref mensaje);
                if (!result) return new ObjectResult(mensaje) { StatusCode = DomainConstants.ObtenerHttpStatusCode(mensaje.Substring(0, 3)) };

                return StatusCode(StatusCodes.Status200OK, "Registro eliminado correctamente");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error interno, por favor vuelva a intentar");
            }
        }
    }
}
