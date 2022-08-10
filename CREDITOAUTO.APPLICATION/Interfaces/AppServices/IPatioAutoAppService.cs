

using CREDITOAUTO.APPLICATION.Dtos;
using CREDITOAUTO.QUERY.DTOs;

namespace CREDITOAUTO.APPLICATION.Interfaces.AppServices
{
    public interface IPatioAutoAppService
    {
        List<PatioAutoQueryDto> ConsultarPatioAutos();
        bool CrearPatioAuto(ref PatioAutoAppDto patio, ref string mensaje);
        bool ActualizarPatioAuto(ref PatioAutoAppDto patio, ref string mensaje);
        bool EliminarPatioAuto(int idPatioAuto, ref string mensaje);
    }
}
