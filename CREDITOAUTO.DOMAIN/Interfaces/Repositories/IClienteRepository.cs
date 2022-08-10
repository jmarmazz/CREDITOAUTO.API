
using CREDITOAUTO.ENTITIES.Entities;

namespace CREDITOAUTO.DOMAIN.Interfaces.Repositories
{ 
    public interface IClienteRepository
    {
        bool CargarCliente(string clientes, ref string mensaje);
        bool CrearCliente(Cliente cliente, ref string mensaje);
        bool ActualizarCliente(Cliente cliente, ref string mensaje);
        bool EliminarCliente(Cliente cliente, ref string mensaje);
    }
}
