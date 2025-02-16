using Microsoft.AspNetCore.Mvc;
using ModularMonolith.Modules.Payment.Domain.Exceptions;
using ModularMonolith.Modules.Payment.Domain.Interfaces;
using PaymentModel = ModularMonolith.Modules.Payment.Domain.Models.Payment;

namespace ModularMonolith.Modules.Payment.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentsController : ControllerBase
{
    private readonly IPaymentService _paymentService;

    public PaymentsController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PaymentModel>>> GetPayments()
    {
        var payments = await _paymentService.GetPaymentsAsync();
        return Ok(payments);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<PaymentModel>> GetPayment(int id)
    {
        try
        {
            var payment = await _paymentService.GetPaymentByIdAsync(id);
            return Ok(payment);
        }
        catch (PaymentNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<PaymentModel>> CreatePayment([FromBody] PaymentModel payment)
    {
        if (payment == null)
        {
            return BadRequest();
        }
        var createdPayment = await _paymentService.CreatePaymentAsync(payment);
        return CreatedAtAction(nameof(GetPayment), new { id = createdPayment.Id }, createdPayment);
    }
}
