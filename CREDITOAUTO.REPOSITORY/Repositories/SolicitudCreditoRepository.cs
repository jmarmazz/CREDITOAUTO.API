
using CREDITOAUTO.DOMAIN.Interfaces.Repositories;
using CREDITOAUTO.ENTITIES.Entities;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using CREDITOAUTO.REPOSITORY.Models;
using static CREDITOAUTO.APPLICATION.Constants.AppConstants;

namespace CREDITOAUTO.REPOSITORY.Repositories
{
    public sealed class SolicitudCreditoRepository : BaseRepository, ISolicitudCreditoRepository
    {
        public SolicitudCreditoRepository(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
        {
        }

        public bool CrearSolicitudCredito(SolicitudCredito credito, ref string mensaje)
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
                                CmdContext.RegistrarSolicitudCredito(credito);

                                trans.Commit();
                                mensaje = "REGISTRO SOLICITUD CREDITO EN BD - EXITOSO";
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
