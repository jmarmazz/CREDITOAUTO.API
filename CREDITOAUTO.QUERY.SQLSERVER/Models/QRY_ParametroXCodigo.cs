
using Microsoft.EntityFrameworkCore;
using CREDITOAUTO.QUERY.DTOs; 

namespace CREDITOAUTO.QUERY.SQLSERVER.Models
{
    public sealed partial class QueryContext
    {
        internal List<ParametroQueryDto> ConsultarParametroXCodigo(string codigo)
        {
            return ParametroQueryDto.FromSqlRaw("QRY_ParametroXCodigo @p0", codigo).ToList();
        }
    }
}
