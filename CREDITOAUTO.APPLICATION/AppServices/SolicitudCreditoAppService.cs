
using CREDITOAUTO.APPLICATION.AppServices.Extensions;
using CREDITOAUTO.APPLICATION.Dtos;
using CREDITOAUTO.APPLICATION.Interfaces.AppServices;
using CREDITOAUTO.DOMAIN.Interfaces.Repositories; 

namespace CREDITOAUTO.APPLICATION.AppServices
{
    public sealed class SolicitudCreditoAppService : ISolicitudCreditoAppService
    { 
        private readonly ISolicitudCreditoRepository SolicitudCreditoRepository;
        public SolicitudCreditoAppService(ISolicitudCreditoRepository SolicitudCreditoRepository)
        {
            this.SolicitudCreditoRepository = SolicitudCreditoRepository;
        }

        public bool CrearSolicitudCredito(SolicitudCreditoAppDto creditoDto, ref string mensaje)
        {
            try
            {
                var credito = creditoDto.MapToSolicitudCredito();
                var result = SolicitudCreditoRepository.CrearSolicitudCredito(credito, ref mensaje);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
