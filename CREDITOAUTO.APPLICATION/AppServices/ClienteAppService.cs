
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
    public sealed class ClienteAppService : IClienteAppService
    {
        private readonly IClienteQueryService clienteQueryService;
        private readonly IClienteRepository clienteRepository;
        public ClienteAppService(IClienteRepository clienteRepository,
                                IClienteQueryService clienteQueryService)
        {
            this.clienteRepository = clienteRepository;
            this.clienteQueryService = clienteQueryService;
        }  
        
        public bool CargarCliente(string archivo, ref string mensaje)
        {
            try
            {
                var cliAppDto = this.LeerClienteCSV(archivo);
                if (!this.ValidarDuplicado(cliAppDto))
                {
                    mensaje = "Error al cargar clientes, existen datos duplicados";
                    throw new Exception(mensaje);
                }
                var clientesJson = JsonConvert.SerializeObject(cliAppDto);
                var result = clienteRepository.CargarCliente(clientesJson, ref mensaje);
                if (!result)
                    throw new Exception(mensaje);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
         
        public List<ClienteQueryDto> ConsultarClientes()
        {
            try
            {
                string mensaje = null;
                var result = clienteQueryService.ConsultarClientes(ref mensaje);
                if (result == null) throw new Exception(mensaje);
                return result;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool CrearCliente(ref ClienteAppDto cli, ref string mensaje)
        {
            try
            {
                var cliente = cli.MapToCliente();
                var result = clienteRepository.CrearCliente(cliente, ref mensaje);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool ActualizarCliente(ref ClienteAppDto cli, ref string mensaje)
        {
            try
            {
                var cliente = cli.MapToCliente();
                var result = clienteRepository.ActualizarCliente(cliente, ref mensaje);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool EliminarCliente(int idcliente, ref string mensaje)
        {
            try
            {
                var cliente = new Cliente() { IdCliente = idcliente };
                var result = clienteRepository.EliminarCliente(cliente, ref mensaje);
                return result;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<ClienteCsvAppDto> LeerClienteCSV(string archivo)
        {
            List<ClienteCsvAppDto> clientes;
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
                    clientes = csv.GetRecords<ClienteCsvAppDto>().ToList();
                }
                reader.Close();
                return clientes; 
            }
        }

        public bool ValidarDuplicado(List<ClienteCsvAppDto> listCliente)
        {
            if (listCliente.GroupBy(x => x.Identificacion).Any(grp => grp.Count() > 1))
                return false;
                
            return true;
        }

    }
}
