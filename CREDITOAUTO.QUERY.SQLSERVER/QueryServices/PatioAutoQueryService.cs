
using CREDITOAUTO.QUERY.SQLSERVER.Models;
using CREDITOAUTO.QUERY.DTOs;
using CREDITOAUTO.QUERY.Interfaces.QueryServices;
using Microsoft.Extensions.DependencyInjection; 

namespace CREDITOAUTO.QUERY.SQLSERVER.QueryServices
{
    public sealed class PatioAutoQueryService : BaseQueryService, IPatioAutoQueryService
    {
        public PatioAutoQueryService(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
        {
        }

        public List<PatioAutoQueryDto> ConsultarPatioAutos( ref string mensaje)
        {
            try
            {
                using (var scope = serviceScopeFactory.CreateScope())
                {
                    using (var QueryContext = scope.ServiceProvider.GetRequiredService<QueryContext>())
                    {
                        var result = QueryContext.ConsultarPatioAutos();
                        if (result == null) return new List<PatioAutoQueryDto>();
                        return result;
                    };
                };
            }
            catch (Exception ex)
            {
                mensaje = $"ERROR CONSULTANDO PATIOAUTOS. EX: {ex.Message}";
                return null;
            }
        }
         
    }
}
