

using CREDITOAUTO.APPLICATION.Dtos;

namespace CREDITOAUTO.APPLICATION.Interfaces.AppServices
{
    public interface ISolicitudCreditoAppService
    {
        bool CrearSolicitudCredito(SolicitudCreditoAppDto cli, ref string mensaje);
    }
}
