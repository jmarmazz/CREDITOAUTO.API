
using CREDITOAUTO.QUERY.SQLSERVER.Models;
using CREDITOAUTO.QUERY.DTOs;
using CREDITOAUTO.QUERY.Interfaces.QueryServices;
using Microsoft.Extensions.DependencyInjection; 

namespace CREDITOAUTO.QUERY.SQLSERVER.QueryServices
{
    public sealed class VehiculoQueryService : BaseQueryService, IVehiculoQueryService
    {
        public VehiculoQueryService(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
        {
        }

        public List<VehiculoQueryDto> ConsultarVehiculos( ref string mensaje)
        {
            try
            {
                using (var scope = serviceScopeFactory.CreateScope())
                {
                    using (var QueryContext = scope.ServiceProvider.GetRequiredService<QueryContext>())
                    {
                        var result = QueryContext.ConsultarVehiculos();
                        if (result == null) return new List<VehiculoQueryDto>();
                        return result;
                    };
                };
            }
            catch (Exception ex)
            {
                mensaje = $"ERROR CONSULTANDO VEHICULOS. EX: {ex.Message}";
                return null;
            }
        }
         
    }
}
