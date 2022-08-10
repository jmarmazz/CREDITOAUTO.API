using CsvHelper;
using CsvHelper.Configuration;
using Newtonsoft.Json.Linq;
using System.Globalization;

namespace CREDITOAUTO.TEST
{
    public class Cliente
    {
        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Edad { get; set; }
        public string FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string EstadoCivil { get; set; }
        public string IdentificacionConyugue { get; set; }
        public string NombreConyugue { get; set; }
        public string SujetoCredito { get; set; }

        public bool CargarCliente(string archivo)
        {
            List<Cliente> clientes;
            try
            {
                if (!File.Exists(archivo))
                    return false;

                using (var reader = new StreamReader(archivo))
                {
                    var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        Delimiter = ";",
                    };
                    using (var csv = new CsvReader(reader, config))
                    {
                        clientes = csv.GetRecords<Cliente>().ToList();
                    }
                    reader.Close();

                    if (clientes?.Count > 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}