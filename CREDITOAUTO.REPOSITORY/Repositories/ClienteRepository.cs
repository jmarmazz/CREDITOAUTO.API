
using CREDITOAUTO.DOMAIN.Interfaces.Repositories;
using CREDITOAUTO.ENTITIES.Entities;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using CREDITOAUTO.REPOSITORY.Models;
using static CREDITOAUTO.APPLICATION.Constants.AppConstants;

namespace CREDITOAUTO.REPOSITORY.Repositories
{
    public sealed class ClienteRepository : BaseRepository, IClienteRepository
    {
        public ClienteRepository(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory)
        {
        }

        public bool CargarCliente(string clientes, ref string mensaje)
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
                                CmdContext.CargarCliente(clientes);

                                trans.Commit();
                                mensaje = "REGISTRO CLIENTE EN BD - EXITOSO";
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

        public bool CrearCliente(Cliente cliente, ref string mensaje)
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
                                CmdContext.RegistrarCliente(cliente, (byte)OperacionCRUD.Insertar);

                                trans.Commit();
                                mensaje = "REGISTRO CLIENTE EN BD - EXITOSO";
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

        public bool ActualizarCliente(Cliente cliente, ref string mensaje)
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
                                CmdContext.RegistrarCliente(cliente, (byte)OperacionCRUD.Actualizar);

                                trans.Commit();
                                mensaje = "ACTUALIZAR CLIENTE EN BD - EXITOSO";
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

        public bool EliminarCliente(Cliente cliente, ref string mensaje)
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
                                CmdContext.RegistrarCliente(cliente, (byte)OperacionCRUD.Eliminar);

                                trans.Commit();
                                mensaje = "ELIMINAR CLIENTE EN BD - EXITOSO";
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
