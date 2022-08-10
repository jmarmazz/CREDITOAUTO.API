
namespace CREDITOAUTO.QUERY.DTOs
{
    public sealed class ClienteQueryDto
    {
        public int IdCliente { get; set; }
        public string Identificacion { get; set; } 
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public byte Edad { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string EstadoCivil { get; set; }
        public string IdentificacionConyugue { get; set; }
        public string NombreConyugue { get; set; }
        public bool SujetoCredito { get; set; } 
        public bool Estado { get; set; }
    }
}
