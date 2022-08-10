
using CREDITOAUTO.QUERY.SQLSERVER.Models;
using CREDITOAUTO.QUERY.DTOs;
using CREDITOAUTO.QUERY.Interfaces.QueryServices;
using Microsoft.Extensions.DependencyInjection; 

namespace CREDITOAUTO.QUERY.SQLSERVER.QueryServices
{
    public sealed class ClienteQueryService : BaseQueryService, IClienteQueryService
    {
        public ClienteQueryService(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
        {
        }

        public List<ClienteQueryDto> ConsultarClientes( ref string mensaje)
        {
            try
            {
                using (var scope = serviceScopeFactory.CreateScope())
                {
                    using (var QueryContext = scope.ServiceProvider.GetRequiredService<QueryContext>())
                    {
                        var result = QueryContext.ConsultarClientes();
                        if (result == null) return new List<ClienteQueryDto>();
                        return result;
                    };
                };
            }
            catch (Exception ex)
            {
                mensaje = $"ERROR CONSULTANDO CLIENTES. EX: {ex.Message}";
                return null;
            }
        }
         
    }
}
