
using CREDITOAUTO.QUERY.DTOs;
using Microsoft.EntityFrameworkCore;  

namespace CREDITOAUTO.QUERY.SQLSERVER.Models
{
    public sealed partial class QueryContext
    {
        internal List<ClienteQueryDto> ConsultarClientes()
        {
            return ClienteQueryDto.FromSqlRaw("QRY_Clientes").ToList();
        }
    }
}
