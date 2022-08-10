
using CREDITOAUTO.QUERY.DTOs;
using Microsoft.EntityFrameworkCore;  

namespace CREDITOAUTO.QUERY.SQLSERVER.Models
{
    public sealed partial class QueryContext
    {
        internal List<PatioAutoQueryDto> ConsultarPatioAutos()
        {
            return PatioAutoQueryDto.FromSqlRaw("QRY_PatioAutos").ToList();
        }
    }
}
