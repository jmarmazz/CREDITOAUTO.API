
using CREDITOAUTO.APPLICATION.AppServices.Extensions;
using CREDITOAUTO.APPLICATION.Dtos;
using CREDITOAUTO.APPLICATION.Interfaces.AppServices;
using CREDITOAUTO.DOMAIN.Interfaces.Repositories;
using CREDITOAUTO.ENTITIES.Entities;
using CREDITOAUTO.QUERY.DTOs;
using CREDITOAUTO.QUERY.Interfaces.QueryServices;
using CsvHelper;
using CsvHelper.Configuration;
using Newtonsoft.Json;
using System.Globalization;
using System.Text;

namespace CREDITOAUTO.APPLICATION.AppServices
{
    public sealed class VehiculoAppService : IVehiculoAppService
    {
        private readonly IVehiculoQueryService vehiculoQueryService;
        private readonly IVehiculoRepository vehiculoRepository;
        public VehiculoAppService(IVehiculoRepository vehiculoRepository,
                                IVehiculoQueryService vehiculoQueryService)
        {
            this.vehiculoRepository = vehiculoRepository;
            this.vehiculoQueryService = vehiculoQueryService;
        }  
         
         
        public List<VehiculoQueryDto> ConsultarVehiculos()
        {
            try
            {
                string mensaje = null;
                var result = vehiculoQueryService.ConsultarVehiculos(ref mensaje);
                if (result == null) throw new Exception(mensaje);
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool CrearVehiculo(ref VehiculoAppDto cli, ref string mensaje)
        {
            try
            {
                var Vehiculo = cli.MapToVehiculo();
                var result = vehiculoRepository.CrearVehiculo(Vehiculo, ref mensaje);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool ActualizarVehiculo(ref VehiculoAppDto cli, ref string mensaje)
        {
            try
            {
                var Vehiculo = cli.MapToVehiculo();
                var result = vehiculoRepository.ActualizarVehiculo(Vehiculo, ref mensaje);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool EliminarVehiculo(int idVehiculo, ref string mensaje)
        {
            try
            {
                var Vehiculo = new Vehiculo() { IdVehiculo = idVehiculo };
                var result = vehiculoRepository.EliminarVehiculo(Vehiculo, ref mensaje);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
