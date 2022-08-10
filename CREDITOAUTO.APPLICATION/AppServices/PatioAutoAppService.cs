
using CREDITOAUTO.APPLICATION.AppServices.Extensions;
using CREDITOAUTO.APPLICATION.Dtos;
using CREDITOAUTO.APPLICATION.Interfaces.AppServices;
using CREDITOAUTO.DOMAIN.Interfaces.Repositories;
using CREDITOAUTO.ENTITIES.Entities;
using CREDITOAUTO.QUERY.DTOs;
using CREDITOAUTO.QUERY.Interfaces.QueryServices;
using CsvHelper;
using CsvHelper.Configuration;
using Newtonsoft.Json;
using System.Globalization;
using System.Text;

namespace CREDITOAUTO.APPLICATION.AppServices
{
    public sealed class PatioAutoAppService : IPatioAutoAppService
    {
        private readonly IPatioAutoQueryService patioAutoQueryService;
        private readonly IPatioAutoRepository patioAutoRepository;
        public PatioAutoAppService(IPatioAutoRepository patioAutoRepository,
                                IPatioAutoQueryService patioAutoQueryService)
        {
            this.patioAutoRepository = patioAutoRepository;
            this.patioAutoQueryService = patioAutoQueryService;
        }  
         
         
        public List<PatioAutoQueryDto> ConsultarPatioAutos()
        {
            try
            {
                string mensaje = null;
                var result = patioAutoQueryService.ConsultarPatioAutos(ref mensaje);
                if (result == null) throw new Exception(mensaje);
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool CrearPatioAuto(ref PatioAutoAppDto cli, ref string mensaje)
        {
            try
            {
                var PatioAuto = cli.MapToPatioAuto();
                var result = patioAutoRepository.CrearPatioAuto(PatioAuto, ref mensaje);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool ActualizarPatioAuto(ref PatioAutoAppDto cli, ref string mensaje)
        {
            try
            {
                var PatioAuto = cli.MapToPatioAuto();
                var result = patioAutoRepository.ActualizarPatioAuto(PatioAuto, ref mensaje);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool EliminarPatioAuto(int idPatio, ref string mensaje)
        {
            try
            {
                var PatioAuto = new PatioAuto() { IdPatio = idPatio };
                var result = patioAutoRepository.EliminarPatioAuto(PatioAuto, ref mensaje);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
