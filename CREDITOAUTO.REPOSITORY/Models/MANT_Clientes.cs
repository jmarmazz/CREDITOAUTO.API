using CREDITOAUTO.ENTITIES.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CREDITOAUTO.REPOSITORY.Models
{
    public sealed partial class CmdContext
    {
        internal void RegistrarCliente(Cliente cliente, byte accion)
        {
            var param = new List<SqlParameter>();
            param.Add(new SqlParameter("@p" + param.Count, accion));
            param.Add(new SqlParameter("@p"+ param.Count, cliente.IdCliente));
            param.Add(new SqlParameter("@p" + param.Count, cliente.Identificacion ?? ""));
            param.Add(new SqlParameter("@p" + param.Count, cliente.Nombres ?? ""));
            param.Add(new SqlParameter("@p" + param.Count, cliente.Apellidos ?? ""));
            param.Add(new SqlParameter("@p" + param.Count, cliente.Edad));
            param.Add(new SqlParameter("@p" + param.Count, cliente.FechaNacimiento != default(DateTime) ? cliente.FechaNacimiento : DateTime.Now.Date));
            param.Add(new SqlParameter("@p" + param.Count, cliente.Direccion ?? ""));
            param.Add(new SqlParameter("@p" + param.Count, cliente.Telefono ?? ""));
            param.Add(new SqlParameter("@p" + param.Count, cliente.EstadoCivil ?? ""));
            param.Add(new SqlParameter("@p" + param.Count, cliente.IdentificacionConyugue ?? ""));
            param.Add(new SqlParameter("@p" + param.Count, cliente.NombreConyugue ?? ""));
            param.Add(new SqlParameter("@p" + param.Count, cliente.SujetoCredito));
            param.Add(new SqlParameter() { ParameterName = "@p" + param.Count, SqlDbType = SqlDbType.SmallInt, Direction = ParameterDirection.Output });
            string commandText = "MANT_Cliente ";
            for (var i = 0; i < param.Count - 1; i++) commandText += $"@p{i},";
            commandText += $"@p{param.Count - 1} OUTPUT";
            Database.ExecuteSqlRaw(commandText, param);
            var resp = Convert.ToInt32(param.Last().Value); 
        }
    }
}
