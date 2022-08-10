

namespace CREDITOAUTO.DOMAIN.Interfaces.Repositories
{ 
    public interface IMarcaVehiculoRepository
    {
        bool CargarMarcaVehiculo(string marcas, ref string mensaje);
    }
}
