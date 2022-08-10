using Microsoft.EntityFrameworkCore;

namespace CREDITOAUTO.REPOSITORY.Models
{
    public sealed partial class CmdContext
    {

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}