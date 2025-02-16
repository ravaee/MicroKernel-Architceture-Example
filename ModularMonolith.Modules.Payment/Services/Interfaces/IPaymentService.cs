
using PaymentModel = ModularMonolith.Modules.Payment.Domain.Models.Payment;
namespace ModularMonolith.Modules.Payment.Domain.Interfaces;

public interface IPaymentService
{
    Task<IEnumerable<PaymentModel>> GetPaymentsAsync();
    Task<PaymentModel> GetPaymentByIdAsync(int id);
    Task<PaymentModel> CreatePaymentAsync(PaymentModel payment);
}
