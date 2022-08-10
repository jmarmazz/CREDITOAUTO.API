

using CREDITOAUTO.APPLICATION.Dtos;
using CREDITOAUTO.QUERY.DTOs;

namespace CREDITOAUTO.APPLICATION.Interfaces.AppServices
{
    public interface IClienteAppService
    {
        bool CargarCliente(string archivo, ref string mensaje);
        List<ClienteQueryDto> ConsultarClientes();
        bool CrearCliente(ref ClienteAppDto cli, ref string mensaje);
        bool ActualizarCliente(ref ClienteAppDto cli, ref string mensaje);
        bool EliminarCliente(int idcliente, ref string mensaje);
    }
}
