using ModularMonolith.Modules.TicketManagment.Data.Repositories.Interfaces;
using ModularMonolith.Modules.TicketManagment.Domain.Exceptions;
using ModularMonolith.Modules.TicketManagment.Domain.Models;
using ModularMonolith.Modules.TicketManagment.Services.Interfaces;

namespace ModularMonolith.Modules.TicketManagment.Services;

public class TicketService : ITicketService
{
    private readonly ITicketRepository _ticketRepository;

    public TicketService(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public async Task<IEnumerable<Ticket>> GetTicketsAsync()
    {
        return await _ticketRepository.GetTicketsAsync();
    }

    public async Task<Ticket> GetTicketByIdAsync(int id)
    {
        var ticket = await _ticketRepository.GetTicketByIdAsync(id);

        if (ticket == null)
        {
            throw new TicketNotFoundException(id);
        }
        return ticket;
    }

    public async Task<Ticket> CreateTicketAsync(Ticket ticket)
    {
        return await _ticketRepository.AddTicketAsync(ticket);
    }
}