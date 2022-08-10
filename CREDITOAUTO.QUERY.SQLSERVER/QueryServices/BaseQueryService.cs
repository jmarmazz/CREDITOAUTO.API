﻿using Microsoft.Extensions.DependencyInjection;

namespace CREDITOAUTO.QUERY.SQLSERVER.QueryServices
{
    public abstract class BaseQueryService
    {
        protected readonly IServiceScopeFactory serviceScopeFactory;

        internal BaseQueryService(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
        }
    }
}
