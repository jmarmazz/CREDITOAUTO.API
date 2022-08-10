

using CREDITOAUTO.APPLICATION.Dtos;
using CREDITOAUTO.QUERY.DTOs;

namespace CREDITOAUTO.APPLICATION.Interfaces.AppServices
{
    public interface IVehiculoAppService
    {
        List<VehiculoQueryDto> ConsultarVehiculos();
        bool CrearVehiculo(ref VehiculoAppDto cli, ref string mensaje);
        bool ActualizarVehiculo(ref VehiculoAppDto cli, ref string mensaje);
        bool EliminarVehiculo(int idVehiculo, ref string mensaje);
    }
}
