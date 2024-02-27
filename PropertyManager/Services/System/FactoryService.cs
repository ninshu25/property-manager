using Interfaces.System;
using Microsoft.Extensions.DependencyInjection;

namespace Services.SystemServices
{
    public class FactoryService : IFactoryService
    {
        private readonly IServiceScope _scope;

        public FactoryService(IServiceScopeFactory scopeFactory)
        {
            _scope = scopeFactory.CreateScope();
        }

        public ILoggingService CreateLoggingService()
        {
            return _scope.ServiceProvider.GetRequiredService<ILoggingService>();
        }

    }
}
