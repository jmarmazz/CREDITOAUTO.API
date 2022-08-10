
using CREDITOAUTO.QUERY.DTOs;
using System.Collections.Generic;

namespace CREDITOAUTO.QUERY.Interfaces.QueryServices
{
    public interface IVehiculoQueryService
    {
        List<VehiculoQueryDto> ConsultarVehiculos(ref string mensaje);
    }
}
