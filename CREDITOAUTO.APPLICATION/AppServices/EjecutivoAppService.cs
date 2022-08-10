
using CREDITOAUTO.APPLICATION.Dtos;
using CREDITOAUTO.APPLICATION.Interfaces.AppServices;
using CREDITOAUTO.DOMAIN.Interfaces.Repositories;
using CsvHelper;
using CsvHelper.Configuration;
using Newtonsoft.Json;
using System.Globalization;

namespace CREDITOAUTO.APPLICATION.AppServices
{
    public sealed class EjecutivoAppService : IEjecutivoAppService
    { 
        private readonly IEjecutivoRepository ejecutivoRepository;
        public EjecutivoAppService(IEjecutivoRepository ejecutivoRepository)
        {
            this.ejecutivoRepository = ejecutivoRepository;
        }
        
        public bool CargarEjecutivo(string archivo, ref string mensaje)
        {
            try
            {
                var ejecutivoAppDto = this.LeerEjecutivoCSV(archivo);
                if (!this.ValidarDuplicado(ejecutivoAppDto))
                {
                    mensaje = "Error al cargar ejecutivos, existen datos duplicados";
                    throw new Exception(mensaje);
                }
                var ejecutivosJson = JsonConvert.SerializeObject(ejecutivoAppDto);
                var result = ejecutivoRepository.CargarEjecutivo(ejecutivosJson, ref mensaje);
                if (!result)
                    throw new Exception(mensaje);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<EjecutivoAppDto> LeerEjecutivoCSV(string archivo)
        {
            List<EjecutivoAppDto> ejecutivos;
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
                    ejecutivos = csv.GetRecords<EjecutivoAppDto>().ToList();
                }
                reader.Close();
                return ejecutivos; 
            }
        }

        public bool ValidarDuplicado(List<EjecutivoAppDto> listEjecutivo)
        {
            if (listEjecutivo.GroupBy(x => x.Identificacion).Any(grp => grp.Count() > 1))
                return false;
                
            return true;
        }

    }
}
