
using System.ComponentModel.DataAnnotations;

namespace CREDITOAUTO.API.DataContracts
{
    public sealed class Vehiculo
    { 
        public int IdVehiculo { get; set; }
        [Required]
        public string Placa { get; set; }
        [Required]
        public string Modelo { get; set; }
        [Required]
        public string NumeroChasis { get; set; }
        [Required]
        public short IdMarca { get; set; }
        public string Tipo { get; set; }
        [Required]
        public string Cilindraje { get; set; }
        [Required]
        public decimal Avaluo { get; set; }
    } 

}
