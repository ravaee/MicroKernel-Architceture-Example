using Microsoft.EntityFrameworkCore;
using PaymentModel = ModularMonolith.Modules.Payment.Domain.Models.Payment;

namespace ModularMonolith.Modules.Payment.Data.Repositories;

public class PaymentRepository(PaymentDbContext context) : IPaymentRepository
{
    public async Task<IEnumerable<PaymentModel>> GetPaymentsAsync()
    {
        return await context.Payments.ToListAsync();
    }

    public async Task<PaymentModel> GetPaymentByIdAsync(int id)
    {
        return await context.Payments.FindAsync(id);
    }

    public async Task<PaymentModel> AddPaymentAsync(PaymentModel payment)
    {
        context.Payments.Add(payment);
        await context.SaveChangesAsync();
        return payment;
    }
}
