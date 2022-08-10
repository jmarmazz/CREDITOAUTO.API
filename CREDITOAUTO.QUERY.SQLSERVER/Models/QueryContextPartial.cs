
using CREDITOAUTO.QUERY.DTOs;
using Microsoft.EntityFrameworkCore;

namespace CREDITOAUTO.QUERY.SQLSERVER.Models
{
    public sealed partial class QueryContext
    {
        private DbSet<ParametroQueryDto> ParametroQueryDto { get; set; }
        private DbSet<ClienteQueryDto> ClienteQueryDto { get; set; }
        private DbSet<VehiculoQueryDto> VehiculoQueryDto { get; set; }
        private DbSet<PatioAutoQueryDto> PatioAutoQueryDto { get; set; }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ParametroQueryDto>().HasNoKey().ToView(null);
            modelBuilder.Entity<ClienteQueryDto>().HasNoKey().ToView(null);
            modelBuilder.Entity<VehiculoQueryDto>().HasNoKey().ToView(null);
            modelBuilder.Entity<PatioAutoQueryDto>().HasNoKey().ToView(null); 
        }
    }
}