using CsvHelper;
using CsvHelper.Configuration;
using Newtonsoft.Json.Linq;
using System.Globalization;

namespace CREDITOAUTO.TEST
{
    public class MarcaVehiculo
    {
        public string Marca { get; set; } 

        public bool CargarMarca(string archivo)
        {
            List<MarcaVehiculo> MarcaVehiculos;
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
                        MarcaVehiculos = csv.GetRecords<MarcaVehiculo>().ToList();
                    }
                    reader.Close();

                    if (MarcaVehiculos?.Count > 0)
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