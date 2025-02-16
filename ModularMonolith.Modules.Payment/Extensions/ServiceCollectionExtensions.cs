using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ModularMonolith.Modules.Payment.Data;
using ModularMonolith.Modules.Payment.Data.Repositories;
using ModularMonolith.Modules.Payment.Domain.Interfaces;
using ModularMonolith.Modules.Payment.Services;

namespace ModularMonolith.Modules.Payment.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPaymentModule(this IServiceCollection services)
    {
        services.AddDbContext<PaymentDbContext>(options =>
            options.UseInMemoryDatabase("PaymentDb"));

        services.AddScoped<IPaymentRepository, PaymentRepository>();
        services.AddScoped<IPaymentService, PaymentService>();

        return services;
    }
}
