namespace ModularMonolith.Modules.Payment.Domain.Models;

public class Payment
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public string PaymentMethod { get; set; }
    public DateTime Date { get; set; }
}