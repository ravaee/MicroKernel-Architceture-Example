using PaymentModel = ModularMonolith.Modules.Payment.Domain.Models.Payment;

namespace ModularMonolith.Modules.Payment.Data.Repositories;

public interface IPaymentRepository
{
    Task<IEnumerable<PaymentModel>> GetPaymentsAsync();
    Task<PaymentModel> GetPaymentByIdAsync(int id);
    Task<PaymentModel> AddPaymentAsync(PaymentModel payment);
}