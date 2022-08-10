
using CREDITOAUTO.APPLICATION.AppServices.Extensions;
using CREDITOAUTO.APPLICATION.Dtos;
using CREDITOAUTO.APPLICATION.Interfaces.AppServices;
using CREDITOAUTO.DOMAIN.Interfaces.Repositories;
using CsvHelper;
using CsvHelper.Configuration;
using Newtonsoft.Json;
using System.Globalization;
using System.Text;

namespace CREDITOAUTO.APPLICATION.AppServices
{
    public sealed class MarcaVehiculoAppService : IMarcaVehiculoAppService
    { 
        private readonly IMarcaVehiculoRepository MarcaVehiculoRepository;
        public MarcaVehiculoAppService(IMarcaVehiculoRepository MarcaVehiculoRepository)
        {
            this.MarcaVehiculoRepository = MarcaVehiculoRepository;
        }
        
        public bool CargarMarcaVehiculo(string archivo, ref string mensaje)
        {
            try
            {
                var marcaAppDto = this.LeerMarcaVehiculoCSV(archivo);
                if (!this.ValidarDuplicado(marcaAppDto))
                {
                    mensaje = "Error al cargar marcas de vehiculo, existen datos duplicados";
                    throw new Exception(mensaje);
                }
                var MarcasJson = JsonConvert.SerializeObject(marcaAppDto);
                var result = MarcaVehiculoRepository.CargarMarcaVehiculo(MarcasJson, ref mensaje);
                if (!result)
                    throw new Exception(mensaje);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<MarcaVehiculoAppDto> LeerMarcaVehiculoCSV(string archivo)
        {
            List<MarcaVehiculoAppDto> Marcas;
            if (!File.Exists(archivo))
                return null;

            using (var reader = new StreamReader(archivo))
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ";"
                };
                using (var csv = new CsvReader(reader, config))
                {
                    Marcas = csv.GetRecords<MarcaVehiculoAppDto>().ToList();
                }
                reader.Close();
                return Marcas; 
            }
        }

        public bool ValidarDuplicado(List<MarcaVehiculoAppDto> listMarca)
        {
            if (listMarca.GroupBy(x => x.Marca).Any(grp => grp.Count() > 1))
                return false;
                
            return true;
        }

    }
}
