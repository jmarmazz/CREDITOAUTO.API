
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
    [Route("/PatioAuto")]
    public class PatioAutoController : ControllerBase
    {
        private readonly IPatioAutoAppService patioAutoAppService;

        public PatioAutoController(IPatioAutoAppService patioAutoAppService)
        {
            this.patioAutoAppService = patioAutoAppService;
        }

        [HttpGet]
        public List<PatioAutoQueryDto> Consultar()
        {
            try
            {
                var result = patioAutoAppService.ConsultarPatioAutos();
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
        public IActionResult Crear(PatioAuto patioAuto)
        {
            string mensaje = "";
            bool result = false;
            try
            {
                var PatioAutodto = patioAuto.MapToPatioAutoAppDto();
                result = patioAutoAppService.CrearPatioAuto(ref PatioAutodto, ref mensaje);
                if (!result) return new ObjectResult(mensaje) { StatusCode = DomainConstants.ObtenerHttpStatusCode(mensaje.Substring(0, 3)) };

                return StatusCode(StatusCodes.Status200OK, "Registro ingresado correctamente");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error interno, por favor vuelva a intentar");
            }
        }

        [HttpPut]
        public IActionResult Actualizar(PatioAuto patioAuto)
        {
            string mensaje = "";
            bool result = false;
            try
            { 
                var PatioAutodto = patioAuto.MapToPatioAutoAppDto();
                result = patioAutoAppService.ActualizarPatioAuto(ref PatioAutodto, ref mensaje);
                if (!result) return new ObjectResult(mensaje) { StatusCode = DomainConstants.ObtenerHttpStatusCode(mensaje.Substring(0, 3)) };

                return StatusCode(StatusCodes.Status200OK, "Registro actualizado correctamente");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error interno, por favor vuelva a intentar");
            }
        }

        [HttpDelete]
        public IActionResult Eliminar(int idPatio)
        {
            string mensaje = "";
            bool result = false;
            try
            { 
                result = patioAutoAppService.EliminarPatioAuto(idPatio, ref mensaje);
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
