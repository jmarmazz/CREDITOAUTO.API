
using CREDITOAUTO.DOMAIN.Interfaces.Repositories;
using CREDITOAUTO.ENTITIES.Entities;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using CREDITOAUTO.REPOSITORY.Models;
using static CREDITOAUTO.APPLICATION.Constants.AppConstants;

namespace CREDITOAUTO.REPOSITORY.Repositories
{
    public sealed class PatioAutoRepository : BaseRepository, IPatioAutoRepository
    {
        public PatioAutoRepository(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
        {
        }

        public bool CrearPatioAuto(PatioAuto PatioAuto, ref string mensaje)
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
                                CmdContext.RegistrarPatioAutos(PatioAuto, (byte)OperacionCRUD.Insertar);

                                trans.Commit();
                                mensaje = "REGISTRO PATIOAUTO EN BD - EXITOSO";
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

        public bool ActualizarPatioAuto(PatioAuto PatioAuto, ref string mensaje)
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
                                CmdContext.RegistrarPatioAutos(PatioAuto, (byte)OperacionCRUD.Actualizar);

                                trans.Commit();
                                mensaje = "ACTUALIZAR PATIOAUTO EN BD - EXITOSO";
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

        public bool EliminarPatioAuto(PatioAuto PatioAuto, ref string mensaje)
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
                                CmdContext.RegistrarPatioAutos(PatioAuto, (byte)OperacionCRUD.Eliminar);

                                trans.Commit();
                                mensaje = "ELIMINAR PATIOAUTO EN BD - EXITOSO";
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
