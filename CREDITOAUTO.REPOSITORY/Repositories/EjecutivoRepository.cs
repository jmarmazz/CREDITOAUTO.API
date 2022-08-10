
using CREDITOAUTO.DOMAIN.Interfaces.Repositories;
using CREDITOAUTO.ENTITIES.Entities;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using CREDITOAUTO.REPOSITORY.Models;

namespace CREDITOAUTO.REPOSITORY.Repositories
{
    public sealed class EjecutivoRepository : BaseRepository, IEjecutivoRepository
    {
        public EjecutivoRepository(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
        {
        }

        public bool CargarEjecutivo(string Ejecutivos, ref string mensaje)
        {
            try
            {
                using (var scope = serviceScopeFactory.CreateScope())
                {
                    using (var CmdContext = scope.ServiceProvider.GetRequiredService<CmdContext>())
                    {
                        using (IDbContextTransaction trans = CmdContext.Database.BeginTransaction())
                        {
                            try
                            {
                                CmdContext.CargarEjecutivo(Ejecutivos);

                                trans.Commit();
                                mensaje = "REGISTRO EJECUTIVO EN BD - EXITOSO";
                                return true;
                            }
                            catch (Exception ex)
                            {
                                trans.Rollback();
                                throw ex;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                return false;
            }
        }
    }
}
