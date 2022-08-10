
using CREDITOAUTO.API.DataContracts;
using CREDITOAUTO.API.Extensions;
using CREDITOAUTO.APPLICATION.Interfaces.AppServices;
using CREDITOAUTO.DOMAIN.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;

namespace CREDITOAUTO.API.Controllers
{
    [ApiController]
    [Route("/AsignacionCliente")]
    public class AsignacionClienteController : ControllerBase
    {
        private readonly IAsignacionClienteAppService asignacionClienteAppService;

        public AsignacionClienteController(IAsignacionClienteAppService asignacionClienteAppService)
        {
            this.asignacionClienteAppService = asignacionClienteAppService;
        }

        [HttpPost]
        public IActionResult Crear(AsignacionCliente cliente)
        {
            string mensaje = "";
            bool result = false;
            try
            {
                var clientedto = cliente.MapToAsignacionClienteAppDto();
                result = asignacionClienteAppService.CrearAsignacionCliente(clientedto, ref mensaje);
                if (!result) return new ObjectResult(mensaje) { StatusCode = DomainConstants.ObtenerHttpStatusCode(mensaje.Substring(0, 3)) };

                return StatusCode(StatusCodes.Status200OK, "Registro ingresado correctamente");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error interno, por favor vuelva a intentar");
            }
        }

        [HttpPut]
        public IActionResult Actualizar(AsignacionCliente cliente)
        {
            string mensaje = "";
            bool result = false;
            try
            {
                var clientedto = cliente.MapToAsignacionClienteAppDto();
                result = asignacionClienteAppService.ActualizarAsignacionCliente(clientedto, ref mensaje);
                if (!result) return new ObjectResult(mensaje) { StatusCode = DomainConstants.ObtenerHttpStatusCode(mensaje.Substring(0, 3)) };

                return StatusCode(StatusCodes.Status200OK, "Registro actualizado correctamente");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error interno, por favor vuelva a intentar");
            }
        }

        [HttpDelete]
        public IActionResult Eliminar(int idAsignacion)
        {
            string mensaje = "";
            bool result = false;
            try
            { 
                result = asignacionClienteAppService.EliminarAsignacionCliente(idAsignacion, ref mensaje);
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
