
using System.ComponentModel.DataAnnotations;

namespace CREDITOAUTO.API.DataContracts
{
    public sealed class SolicitudCredito
    {
        [Required]
        public DateTime FechaElaboracion { get; set; }
        [Required]
        public int IdCliente { get; set; }
        [Required]
        public short IdPatio { get; set; }
        [Required]
        public int Vehiculo { get; set; }
        [Required]
        public byte MesesPlazo { get; set; }
        [Required]
        public byte Cuotas { get; set; }
        [Required]
        public decimal Entrada { get; set; }
        [Required]
        public short IdEjecutivo { get; set; } 
        public string Observacion { get; set; }
    } 

}
