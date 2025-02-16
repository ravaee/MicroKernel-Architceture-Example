using System;

namespace ModularMonolith.Modules.Payment.Domain.Exceptions;

public class PaymentNotFoundException : Exception
{
    public PaymentNotFoundException(int id)
        : base($"Payment with ID {id} not found.")
    {
    }
}