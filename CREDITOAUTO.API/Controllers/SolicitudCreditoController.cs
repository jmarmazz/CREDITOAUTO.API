
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
    [Route("/SolicitudCredito")]
    public class SolicitudCreditoController : ControllerBase
    {
        private readonly ISolicitudCreditoAppService solicitudCreditoAppService;

        public SolicitudCreditoController(ISolicitudCreditoAppService solicitudCreditoAppService)
        {
            this.solicitudCreditoAppService = solicitudCreditoAppService;
        }

        [HttpPost]
        public IActionResult Crear(SolicitudCredito credito)
        {
            string mensaje = "";
            bool result = false;
            try
            {
                var creditodto = credito.MapToSolicitudCreditoAppDto();
                result = solicitudCreditoAppService.CrearSolicitudCredito(creditodto, ref mensaje);
                if (!result) return new ObjectResult(mensaje) { StatusCode = DomainConstants.ObtenerHttpStatusCode(mensaje.Substring(0, 3)) };

                return StatusCode(StatusCodes.Status200OK, "Registro ingresado correctamente");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error interno, por favor vuelva a intentar");
            }
        }
    }
}
