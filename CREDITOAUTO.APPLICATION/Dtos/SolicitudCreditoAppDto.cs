

namespace CREDITOAUTO.APPLICATION.Dtos
{
    public sealed class SolicitudCreditoAppDto
    {
        public DateTime FechaElaboracion { get; set; }
        public int IdCliente { get; set; }
        public short IdPatio { get; set; }
        public int Vehiculo { get; set; }
        public byte MesesPlazo { get; set; }
        public byte Cuotas { get; set; }
        public decimal Entrada { get; set; }
        public short IdEjecutivo { get; set; }
        public string Observacion { get; set; }
    } 

}
