
namespace CREDITOAUTO.ENTITIES.Entities
{
    public sealed class AsignacionCliente
    {
        public int IdAsignacion { get; set; }
        public int IdCliente { get; set; } 
        public short IdPatio { get; set; }
        public DateTime FechaAsignacion { get; set; }
    } 

}
