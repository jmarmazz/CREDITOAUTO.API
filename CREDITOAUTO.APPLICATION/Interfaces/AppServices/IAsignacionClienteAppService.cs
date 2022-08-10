

using CREDITOAUTO.APPLICATION.Dtos;

namespace CREDITOAUTO.APPLICATION.Interfaces.AppServices
{
    public interface IAsignacionClienteAppService
    {
        bool CrearAsignacionCliente(AsignacionClienteAppDto asigna, ref string mensaje);
        bool ActualizarAsignacionCliente(AsignacionClienteAppDto asigna, ref string mensaje);
        bool EliminarAsignacionCliente(int idAsigna, ref string mensaje);
    }
}
