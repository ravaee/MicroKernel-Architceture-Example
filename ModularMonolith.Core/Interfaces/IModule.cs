using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ModularMonolith.Core.Interfaces;

public interface IModule
{
    void RegisterServices(IServiceCollection services);
    void WebAppConfiguretion(WebApplication endpoints);
}

