
using CREDITOAUTO.QUERY.DTOs;
using System.Collections.Generic;

namespace CREDITOAUTO.QUERY.Interfaces.QueryServices
{
    public interface IClienteQueryService
    {
        List<ClienteQueryDto> ConsultarClientes(ref string mensaje);
    }
}
