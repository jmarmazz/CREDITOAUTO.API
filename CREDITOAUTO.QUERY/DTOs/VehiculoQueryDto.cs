
namespace CREDITOAUTO.QUERY.DTOs
{
    public sealed class VehiculoQueryDto
    {
        public int IdVehiculo { get; set; }
        public string Placa { get; set; }
        public string Modelo { get; set; }
        public string NumeroChasis { get; set; }
        public short IdMarca { get; set; }
        public string Tipo { get; set; }
        public string Cilindraje { get; set; }
        public decimal Avaluo { get; set; }
        public bool Estado { get; set; }
    }
}
