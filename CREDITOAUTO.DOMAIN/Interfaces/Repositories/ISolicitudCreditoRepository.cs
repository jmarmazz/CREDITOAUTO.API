
using CREDITOAUTO.ENTITIES.Entities;

namespace CREDITOAUTO.DOMAIN.Interfaces.Repositories
{ 
    public interface ISolicitudCreditoRepository
    {
        bool CrearSolicitudCredito(SolicitudCredito credito, ref string mensaje);
    }
}
