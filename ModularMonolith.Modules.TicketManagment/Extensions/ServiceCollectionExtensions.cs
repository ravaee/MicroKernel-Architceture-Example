using Microsoft.Extensions.DependencyInjection;
using ModularMonolith.Modules.TicketManagment.Data.Repositories.Interfaces;
using ModularMonolith.Modules.TicketManagment.Data.Repositories;
using ModularMonolith.Modules.TicketManagment.Data;
using ModularMonolith.Modules.TicketManagment.Services.Interfaces;
using ModularMonolith.Modules.TicketManagment.Services;
using Microsoft.EntityFrameworkCore;

namespace ModularMonolith.Modules.TicketManagment.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddTicketManagement(this IServiceCollection services)
    {

        services.AddScoped<ITicketRepository, TicketRepository>();
        services.AddScoped<ITicketService, TicketService>();

        return services;
    }

    public static IServiceCollection AddTicketDbContext(this IServiceCollection services)
    {

        services.AddDbContext<TicketDbContext>(options =>
                options.UseInMemoryDatabase("TicketDb"));

        return services;
    }


}