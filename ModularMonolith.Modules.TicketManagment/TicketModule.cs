using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolith.Core;
using ModularMonolith.Modules.TicketManagment.Extensions;

namespace ModularMonolith.Modules.TicketManagment;

public class TicketModule : Module
{
    public override void RegisterServices(IServiceCollection services)
    {
        services.AddTicketManagement();
        services.AddTicketDbContext();
    }

    protected override void ConfigModuleWebApplication(WebApplication app)
    {

    }
}
