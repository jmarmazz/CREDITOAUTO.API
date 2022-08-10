using AutoMapper;
using CREDITOAUTO.APPLICATION.Dtos; 
using CREDITOAUTO.ENTITIES.Entities;

namespace CREDITOAUTO.APPLICATION.AppServices.Extensions
{
    public static class AppExtensions
    {
        internal static List<Cliente> MapToCliente(this List<Dtos.ClienteAppDto> obj)
        {
            if (obj.Count == 0) return null;

            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<Dtos.ClienteAppDto, Cliente>());
            var mapper = configuration.CreateMapper();
            return mapper.Map<List<Cliente>>(obj);
        }

        internal static AsignacionCliente MapToAsignacionCliente(this AsignacionClienteAppDto obj)
        {
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<AsignacionClienteAppDto, AsignacionCliente>()
            );
            var mapper = configuration.CreateMapper();
            return mapper.Map<AsignacionCliente>(obj);
        }

        internal static SolicitudCredito MapToSolicitudCredito(this SolicitudCreditoAppDto obj)
        {
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<SolicitudCreditoAppDto, SolicitudCredito>()
            );
            var mapper = configuration.CreateMapper();
            return mapper.Map<SolicitudCredito>(obj);
        }

        internal static Cliente MapToCliente(this ClienteAppDto obj)
        {
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<ClienteAppDto, Cliente>()
            );
            var mapper = configuration.CreateMapper();
            return mapper.Map<Cliente>(obj);
        }

        internal static Vehiculo MapToVehiculo(this VehiculoAppDto obj)
        {
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<VehiculoAppDto, Vehiculo>()
            );
            var mapper = configuration.CreateMapper();
            return mapper.Map<Vehiculo>(obj);
        }

        internal static PatioAuto MapToPatioAuto(this PatioAutoAppDto obj)
        {
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<PatioAutoAppDto, PatioAuto>()
            );
            var mapper = configuration.CreateMapper();
            return mapper.Map<PatioAuto>(obj);
        }
        
    }
}
