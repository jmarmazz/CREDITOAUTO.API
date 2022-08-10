

namespace CREDITOAUTO.APPLICATION.Dtos
{
    public sealed class AsignacionClienteAppDto
    {
        public int IdAsignacion { get; set; }
        public int IdCliente { get; set; } 
        public short IdPatio { get; set; }
        public DateTime FechaAsignacion { get; set; }
    } 

}
