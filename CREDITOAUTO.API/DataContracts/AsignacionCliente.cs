
using System.ComponentModel.DataAnnotations;

namespace CREDITOAUTO.API.DataContracts
{
    public sealed class AsignacionCliente
    {
        public int IdAsignacion { get; set; }
        [Required]
        public int IdCliente { get; set; }
        [Required]
        public short IdPatio { get; set; }
        [Required]
        public DateTime FechaAsignacion { get; set; }
    } 

}
