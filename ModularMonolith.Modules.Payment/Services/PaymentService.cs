using ModularMonolith.Modules.Payment.Data.Repositories;
using ModularMonolith.Modules.Payment.Domain.Exceptions;
using ModularMonolith.Modules.Payment.Domain.Interfaces;
using PaymentModel = ModularMonolith.Modules.Payment.Domain.Models.Payment;

namespace ModularMonolith.Modules.Payment.Services;

public class PaymentService(IPaymentRepository repository) : IPaymentService
{
    public async Task<IEnumerable<PaymentModel>> GetPaymentsAsync()
    {
        return await repository.GetPaymentsAsync();
    }

    public async Task<PaymentModel> GetPaymentByIdAsync(int id)
    {
        var payment = await repository.GetPaymentByIdAsync(id);

        if (payment is null)
        {
            throw new PaymentNotFoundException(id);
        }

        return payment;
    }

    public async Task<PaymentModel> CreatePaymentAsync(PaymentModel payment)
    {
        return await repository.AddPaymentAsync(payment);
    }
}
