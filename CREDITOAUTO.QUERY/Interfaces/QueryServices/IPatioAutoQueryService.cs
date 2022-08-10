
using CREDITOAUTO.QUERY.DTOs;
using System.Collections.Generic;

namespace CREDITOAUTO.QUERY.Interfaces.QueryServices
{
    public interface IPatioAutoQueryService
    {
        List<PatioAutoQueryDto> ConsultarPatioAutos(ref string mensaje);
    }
}
