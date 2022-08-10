
using CREDITOAUTO.ENTITIES.Entities;

namespace CREDITOAUTO.DOMAIN.Interfaces.Repositories
{ 
    public interface IVehiculoRepository
    {
        bool CrearVehiculo(Vehiculo vehiculo, ref string mensaje);
        bool ActualizarVehiculo(Vehiculo vehiculo, ref string mensaje);
        bool EliminarVehiculo(Vehiculo vehiculo, ref string mensaje);
    }
}
