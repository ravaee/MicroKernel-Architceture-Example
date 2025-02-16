using ModularMonolith.Modules.TicketManagment.Domain.Models;

namespace ModularMonolith.Modules.TicketManagment.Services.Interfaces;

public interface ITicketService
{
    Task<IEnumerable<Ticket>> GetTicketsAsync();
    Task<Ticket> GetTicketByIdAsync(int id);
    Task<Ticket> CreateTicketAsync(Ticket ticket);
}
