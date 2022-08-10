
using CREDITOAUTO.APPLICATION.AppServices.Extensions;
using CREDITOAUTO.APPLICATION.Dtos;
using CREDITOAUTO.APPLICATION.Interfaces.AppServices;
using CREDITOAUTO.DOMAIN.Interfaces.Repositories;
using CREDITOAUTO.ENTITIES.Entities;

namespace CREDITOAUTO.APPLICATION.AppServices
{
    public sealed class AsignacionClienteAppService : IAsignacionClienteAppService
    { 
        private readonly IAsignacionClienteRepository asignacionClienteRepository;
        public AsignacionClienteAppService(IAsignacionClienteRepository asignacionClienteRepository)
        {
            this.asignacionClienteRepository = asignacionClienteRepository;
        }

        public bool CrearAsignacionCliente(AsignacionClienteAppDto asignacion, ref string mensaje)
        {
            try
            {
                var asigna = asignacion.MapToAsignacionCliente();
                var result = asignacionClienteRepository.CrearAsignacionCliente(asigna, ref mensaje);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ActualizarAsignacionCliente(AsignacionClienteAppDto asignacion, ref string mensaje)
        {
            try
            {
                var asigna = asignacion.MapToAsignacionCliente();
                var result = asignacionClienteRepository.ActualizarAsignacionCliente(asigna, ref mensaje);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EliminarAsignacionCliente(int idAsignacion, ref string mensaje)
        {
            try
            {
                var asignacion = new AsignacionCliente() { IdAsignacion = idAsignacion };
                var result = asignacionClienteRepository.EliminarAsignacionCliente(asignacion, ref mensaje);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
