
namespace CREDITOAUTO.DOMAIN.Interfaces.Repositories
{ 
    public interface IEjecutivoRepository
    {
        bool CargarEjecutivo(string ejecutivos, ref string mensaje);
    }
}
