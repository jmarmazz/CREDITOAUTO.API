using CREDITOAUTO.APPLICATION.AppServices;
using CREDITOAUTO.APPLICATION.Interfaces.AppServices;
using CREDITOAUTO.DOMAIN.Interfaces.Repositories;
using CREDITOAUTO.REPOSITORY.Models;
using CREDITOAUTO.REPOSITORY.Repositories;
using Microsoft.EntityFrameworkCore;
using CREDITOAUTO.QUERY.QueryServices;
using CREDITOAUTO.DOMAIN.Constants;
using CREDITOAUTO.API.Parameters;
using CREDITOAUTO.QUERY.SQLSERVER.QueryServices;
using CREDITOAUTO.QUERY.SQLSERVER.Models;
using CREDITOAUTO.QUERY.Interfaces.QueryServices;

var builder = WebApplication.CreateBuilder(args); 
// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IParametroQueryService, ParametroQueryService>();
builder.Services.AddScoped<IClienteAppService, ClienteAppService>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteQueryService, ClienteQueryService>();
builder.Services.AddScoped<IMarcaVehiculoAppService, MarcaVehiculoAppService>();
builder.Services.AddScoped<IMarcaVehiculoRepository, MarcaVehiculoRepository>();
builder.Services.AddScoped<IEjecutivoAppService, EjecutivoAppService>();
builder.Services.AddScoped<IEjecutivoRepository, EjecutivoRepository>();
builder.Services.AddScoped<IAsignacionClienteAppService, AsignacionClienteAppService>();
builder.Services.AddScoped<IAsignacionClienteRepository, AsignacionClienteRepository>();
builder.Services.AddScoped<IPatioAutoAppService, PatioAutoAppService>();
builder.Services.AddScoped<IPatioAutoRepository, PatioAutoRepository>();
builder.Services.AddScoped<IPatioAutoQueryService, PatioAutoQueryService>();
builder.Services.AddScoped<IVehiculoAppService, VehiculoAppService>();
builder.Services.AddScoped<IVehiculoRepository, VehiculoRepository>();
builder.Services.AddScoped<IVehiculoQueryService, VehiculoQueryService>();
builder.Services.AddScoped<ISolicitudCreditoAppService, SolicitudCreditoAppService>();
builder.Services.AddScoped<ISolicitudCreditoRepository, SolicitudCreditoRepository>();

var CadenaConexionRead = builder.Configuration.GetSection("DBRead").GetSection("DataSource").Value;
var CadenaConexionWrite = builder.Configuration.GetSection("DBWrite").GetSection("DataSource").Value;
builder.Services.AddDbContext<QueryContext>(options => options.UseSqlServer(CadenaConexionRead));
builder.Services.AddDbContext<CmdContext>(options => options.UseSqlServer(CadenaConexionWrite));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Carga Inicial csv
using (var serviceScope = app.Services.CreateScope())
{
    string mensaje = null;
    try
    {
        var services = serviceScope.ServiceProvider;
        var parametroQueryService = services.GetRequiredService<IParametroQueryService>();
        string codigos = DomainConstants.PARAMETRO_RUTA_CSVCREDITOCLIENTE + "," + DomainConstants.PARAMETRO_RUTA_CSVCREDITOMARCA + "," + DomainConstants.PARAMETRO_RUTA_CSVCREDITOEJECUTIVO;
        var result = parametroQueryService.ConsultarParametroXCodigo(codigos, ref mensaje);
        if (result == null)
        {
            if (mensaje == null) mensaje = $"Parámetro [{DomainConstants.PARAMETRO_RUTA_CSVCREDITOCLIENTE},{DomainConstants.PARAMETRO_RUTA_CSVCREDITOMARCA},{DomainConstants.PARAMETRO_RUTA_CSVCREDITOEJECUTIVO} ] requerido";
            throw new Exception(mensaje);
        }

        ApiParameters.RutaCsvCreditoCliente = result.FirstOrDefault(x=> x.Codigo == DomainConstants.PARAMETRO_RUTA_CSVCREDITOCLIENTE).Valor;
        ApiParameters.RutaCsvCreditoMarca = result.FirstOrDefault(x => x.Codigo == DomainConstants.PARAMETRO_RUTA_CSVCREDITOMARCA).Valor;
        ApiParameters.RutaCsvCreditoEjecutivo = result.FirstOrDefault(x => x.Codigo == DomainConstants.PARAMETRO_RUTA_CSVCREDITOEJECUTIVO).Valor;

        var clienteAppService = services.GetRequiredService<IClienteAppService>();
        bool resultCli = clienteAppService.CargarCliente(ApiParameters.RutaCsvCreditoCliente, ref mensaje);
        if(!resultCli) Console.WriteLine(mensaje);

        var marcaAppService = services.GetRequiredService<IMarcaVehiculoAppService>();
        bool resultMar = marcaAppService.CargarMarcaVehiculo(ApiParameters.RutaCsvCreditoMarca, ref mensaje);
        if (!resultMar) Console.WriteLine(mensaje);

        var ejecutivoAppService = services.GetRequiredService<IEjecutivoAppService>();
        bool resultEje = ejecutivoAppService.CargarEjecutivo(ApiParameters.RutaCsvCreditoEjecutivo, ref mensaje);
        if (!resultEje) Console.WriteLine(mensaje);

    }
    catch (Exception ex)
    {
        // Registrar LOG
        Console.WriteLine(ex.Message);
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();


