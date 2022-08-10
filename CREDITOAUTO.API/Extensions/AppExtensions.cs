using AutoMapper;
using CREDITOAUTO.API.DataContracts;
using CREDITOAUTO.APPLICATION.Dtos;

namespace CREDITOAUTO.API.Extensions
{
    public static class AppExtensions
    {
        internal static AsignacionClienteAppDto MapToAsignacionClienteAppDto(this AsignacionCliente obj)
        {
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<AsignacionCliente, AsignacionClienteAppDto>() 
            );
            var mapper = configuration.CreateMapper();
            return mapper.Map<AsignacionClienteAppDto>(obj);
        }

        internal static SolicitudCreditoAppDto MapToSolicitudCreditoAppDto(this SolicitudCredito obj)
        {
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<SolicitudCredito, SolicitudCreditoAppDto>()
            );
            var mapper = configuration.CreateMapper();
            return mapper.Map<SolicitudCreditoAppDto>(obj);
        }

        internal static ClienteAppDto MapToClienteAppDto(this Cliente obj)
        {
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<Cliente, ClienteAppDto>()
            );
            var mapper = configuration.CreateMapper();
            return mapper.Map<ClienteAppDto>(obj);
        }

        internal static VehiculoAppDto MapToVehiculoAppDto(this Vehiculo obj)
        {
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<Vehiculo, VehiculoAppDto>()
            );
            var mapper = configuration.CreateMapper();
            return mapper.Map<VehiculoAppDto>(obj);
        }

        internal static PatioAutoAppDto MapToPatioAutoAppDto(this PatioAuto obj)
        {
            var configuration = new MapperConfiguration(cfg => cfg.CreateMap<PatioAuto, PatioAutoAppDto>()
            );
            var mapper = configuration.CreateMapper();
            return mapper.Map<PatioAutoAppDto>(obj);
        }
        
    }
}
