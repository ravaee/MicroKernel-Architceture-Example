using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolith.Core;
using ModularMonolith.Modules.Payment.Extensions;

namespace ModularMonolith.Modules.Payment;

public class TicketModule : Module
{
    public override void RegisterServices(IServiceCollection services)
    {
        services.AddPaymentModule();
    }

    protected override void ConfigModuleWebApplication(WebApplication app)
    {

    }
}