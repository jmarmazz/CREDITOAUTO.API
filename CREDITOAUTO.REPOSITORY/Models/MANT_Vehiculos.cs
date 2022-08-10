using CREDITOAUTO.ENTITIES.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CREDITOAUTO.REPOSITORY.Models
{
    public sealed partial class CmdContext
    {
        internal void RegistrarVehiculos(Vehiculo vehiculo, byte accion)
        {
            var param = new List<SqlParameter>();
            param.Add(new SqlParameter("@p" + param.Count, accion));
            param.Add(new SqlParameter("@p"+ param.Count, vehiculo.IdVehiculo));
            param.Add(new SqlParameter("@p" + param.Count, vehiculo.Placa ?? ""));
            param.Add(new SqlParameter("@p" + param.Count, vehiculo.Modelo ?? ""));
            param.Add(new SqlParameter("@p" + param.Count, vehiculo.NumeroChasis ?? ""));
            param.Add(new SqlParameter("@p" + param.Count, vehiculo.IdMarca));
            param.Add(new SqlParameter("@p" + param.Count, vehiculo.Tipo ?? ""));
            param.Add(new SqlParameter("@p" + param.Count, vehiculo.Cilindraje ?? ""));
            param.Add(new SqlParameter("@p" + param.Count, vehiculo.Avaluo));

            param.Add(new SqlParameter() { ParameterName = "@p" + param.Count, SqlDbType = SqlDbType.SmallInt, Direction = ParameterDirection.Output });
            string commandText = "MANT_Vehiculo ";
            for (var i = 0; i < param.Count - 1; i++) commandText += $"@p{i},";
            commandText += $"@p{param.Count - 1} OUTPUT";
            Database.ExecuteSqlRaw(commandText, param);
            var resp = Convert.ToInt32(param.Last().Value); 
        }
    }
}
