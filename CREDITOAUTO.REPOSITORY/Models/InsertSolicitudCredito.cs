
using CREDITOAUTO.DOMAIN.Constants;
using CREDITOAUTO.ENTITIES.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CREDITOAUTO.REPOSITORY.Models
{
    public sealed partial class CmdContext
    {
        internal void RegistrarSolicitudCredito(SolicitudCredito credito)
        {
            var param = new List<SqlParameter>();
            param.Add(new SqlParameter("@p" + param.Count, credito.FechaElaboracion));
            param.Add(new SqlParameter("@p" + param.Count, credito.IdCliente));
            param.Add(new SqlParameter("@p" + param.Count, credito.IdPatio));
            param.Add(new SqlParameter("@p" + param.Count, credito.Vehiculo));
            param.Add(new SqlParameter("@p" + param.Count, credito.MesesPlazo));
            param.Add(new SqlParameter("@p" + param.Count, credito.Cuotas));
            param.Add(new SqlParameter("@p" + param.Count, credito.Entrada));
            param.Add(new SqlParameter("@p" + param.Count, credito.IdEjecutivo));
            param.Add(new SqlParameter("@p" + param.Count, credito.Observacion));
            param.Add(new SqlParameter("@p" + param.Count, EstadoSolicitud.Registrada)); 
            param.Add(new SqlParameter() { ParameterName = "@p" + param.Count, SqlDbType = SqlDbType.SmallInt, Direction = ParameterDirection.Output });
            string commandText = "INS_SolicitudCredito ";
            for (var i = 0; i < param.Count - 1; i++) commandText += $"@p{i},";
            commandText += $"@p{param.Count - 1} OUTPUT";
            Database.ExecuteSqlRaw(commandText, param);
            var resp = Convert.ToInt32(param.Last().Value); 
        }
    }
}
