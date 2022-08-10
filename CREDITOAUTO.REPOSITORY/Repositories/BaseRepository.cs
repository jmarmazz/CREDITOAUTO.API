using Microsoft.Extensions.DependencyInjection;

namespace CREDITOAUTO.REPOSITORY.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly IServiceScopeFactory serviceScopeFactory;

        internal BaseRepository(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
        }
    }
}
