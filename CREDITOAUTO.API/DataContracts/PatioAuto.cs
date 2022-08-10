
using System.ComponentModel.DataAnnotations;

namespace CREDITOAUTO.API.DataContracts
{
    public sealed class PatioAuto
    {
        public int IdPatio { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        public string NumPuntoVenta { get; set; }
    } 

}
