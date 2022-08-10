
using CREDITOAUTO.QUERY.DTOs;

namespace CREDITOAUTO.QUERY.QueryServices
{
    public interface IParametroQueryService
    {
        List<ParametroQueryDto> ConsultarParametroXCodigo(string codigo, ref string mensaje);
    }
}
