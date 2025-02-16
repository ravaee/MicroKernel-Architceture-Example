using Microsoft.EntityFrameworkCore;
using PaymentModel = ModularMonolith.Modules.Payment.Domain.Models.Payment;

namespace ModularMonolith.Modules.Payment.Data;

public class PaymentDbContext(DbContextOptions<PaymentDbContext> options) : DbContext(options)
{
    public required DbSet<PaymentModel> Payments { get; set; }
}
