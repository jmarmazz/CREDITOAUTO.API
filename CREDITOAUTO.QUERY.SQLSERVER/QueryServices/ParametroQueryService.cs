
using CREDITOAUTO.QUERY.DTOs;
using CREDITOAUTO.QUERY.QueryServices;
using Microsoft.Extensions.DependencyInjection;
using CREDITOAUTO.QUERY.SQLSERVER.Models;
using System;
using System.Collections.Generic;

namespace CREDITOAUTO.QUERY.SQLSERVER.QueryServices
{
    public sealed class ParametroQueryService : BaseQueryService, IParametroQueryService
    {
        public ParametroQueryService(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
        {
        }

        public List<ParametroQueryDto> ConsultarParametroXCodigo(string codigo, ref string mensaje)
        {
            try
            {
                using (var scope = serviceScopeFactory.CreateScope())
                {
                    using (var QueryContext = scope.ServiceProvider.GetRequiredService<QueryContext>())
                    {
                        var result = QueryContext.ConsultarParametroXCodigo(codigo);
                        if (result == null) return new List<ParametroQueryDto>();
                        return result;
                    };
                };
            }
            catch (Exception ex)
            {
                mensaje = $"ERROR CONSULTANDO PARAMETRO. EX: {ex.Message}";
                return null;
            }
        }
         
    }
}
