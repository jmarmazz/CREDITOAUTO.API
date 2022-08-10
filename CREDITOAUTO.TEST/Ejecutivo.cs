using CsvHelper;
using CsvHelper.Configuration;
using Newtonsoft.Json.Linq;
using System.Globalization;

namespace CREDITOAUTO.TEST
{
    public class Ejecutivo
    {
        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string TelefonoConvencional { get; set; }
        public string Celular { get; set; }
        public string PatioLabora { get; set; }
        public string Edad { get; set; }

        public bool CargarEjecutivo(string archivo)
        {
            List<Ejecutivo> ejecutivos;
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
                        ejecutivos = csv.GetRecords<Ejecutivo>().ToList();
                    }
                    reader.Close();

                    if (ejecutivos?.Count > 0)
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