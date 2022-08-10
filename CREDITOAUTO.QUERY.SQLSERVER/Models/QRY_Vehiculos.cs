
using CREDITOAUTO.QUERY.DTOs;
using Microsoft.EntityFrameworkCore;  

namespace CREDITOAUTO.QUERY.SQLSERVER.Models
{
    public sealed partial class QueryContext
    {
        internal List<VehiculoQueryDto> ConsultarVehiculos()
        {
            return VehiculoQueryDto.FromSqlRaw("QRY_Vehiculos").ToList();
        }
    }
}
