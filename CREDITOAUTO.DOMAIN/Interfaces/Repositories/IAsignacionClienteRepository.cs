
using CREDITOAUTO.ENTITIES.Entities;

namespace CREDITOAUTO.DOMAIN.Interfaces.Repositories
{ 
    public interface IAsignacionClienteRepository
    {
        bool CrearAsignacionCliente(AsignacionCliente cliente, ref string mensaje);
        bool ActualizarAsignacionCliente(AsignacionCliente cliente, ref string mensaje);
        bool EliminarAsignacionCliente(AsignacionCliente cliente, ref string mensaje);
    }
}
