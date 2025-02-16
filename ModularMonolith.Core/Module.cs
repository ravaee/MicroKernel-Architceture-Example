using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolith.Core.Interfaces;

namespace ModularMonolith.Core;

public abstract class Module : IModule
{
    protected abstract void ConfigModuleWebApplication(WebApplication app);

    public void WebAppConfiguretion(WebApplication app)
    {
        ConfigModuleWebApplication(app);
    }

    public abstract void RegisterServices(IServiceCollection services);
}
