using Microsoft.AspNetCore.Mvc;
using ModularMonolith.Modules.TicketManagment.Domain.Exceptions;
using ModularMonolith.Modules.TicketManagment.Domain.Models;
using ModularMonolith.Modules.TicketManagment.Services.Interfaces;

namespace ModularMonolith.Modules.TicketManagment.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TicketsController : ControllerBase
{
    private readonly ITicketService _ticketService;
    public TicketsController(ITicketService ticketService)
    {
        _ticketService = ticketService;
    }

    [HttpGet]
    public async Task<IEnumerable<Ticket>> GetTickets()
        => await _ticketService.GetTicketsAsync();

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetTicket(int id)
    {
        try
        {
            var ticket = await _ticketService.GetTicketByIdAsync(id);
            return Ok(ticket);
        }
        catch (TicketNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateTicket([FromBody] Ticket ticket)
    {
        if (ticket == null)
            return BadRequest();
        var created = await _ticketService.CreateTicketAsync(ticket);
        return CreatedAtAction(nameof(GetTicket), new { id = created.Id }, created);
    }
}