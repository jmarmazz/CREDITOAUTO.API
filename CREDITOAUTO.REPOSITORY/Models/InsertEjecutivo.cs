using CREDITOAUTO.ENTITIES.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CREDITOAUTO.REPOSITORY.Models
{
    public sealed partial class CmdContext
    {
        internal void CargarEjecutivo(string ejecutivos)
        {
            var param = new List<SqlParameter>(); 
            param.Add(new SqlParameter("@p" + param.Count, ejecutivos)); 
            param.Add(new SqlParameter() { ParameterName = "@p" + param.Count, SqlDbType = SqlDbType.SmallInt, Direction = ParameterDirection.Output });
            string commandText = "INS_Ejecutivo ";
            for (var i = 0; i < param.Count - 1; i++) commandText += $"@p{i},";
            commandText += $"@p{param.Count - 1} OUTPUT";
            Database.ExecuteSqlRaw(commandText, param);
            var resp = Convert.ToInt32(param.Last().Value);
        }
    }
}
