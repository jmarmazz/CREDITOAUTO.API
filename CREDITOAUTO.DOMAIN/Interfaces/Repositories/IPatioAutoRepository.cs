
using CREDITOAUTO.ENTITIES.Entities;

namespace CREDITOAUTO.DOMAIN.Interfaces.Repositories
{ 
    public interface IPatioAutoRepository
    {
        bool CrearPatioAuto(PatioAuto patioAuto, ref string mensaje);
        bool ActualizarPatioAuto(PatioAuto patioAuto, ref string mensaje);
        bool EliminarPatioAuto(PatioAuto patioAuto, ref string mensaje);
    }
}
