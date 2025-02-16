using ModularMonolith.Modules.TicketManagment.Domain.Models;

namespace ModularMonolith.Modules.TicketManagment.Data.Repositories.Interfaces;

public interface ITicketRepository
{
    Task<IEnumerable<Ticket>> GetTicketsAsync();
    Task<Ticket> GetTicketByIdAsync(int id);
    Task<Ticket> AddTicketAsync(Ticket ticket);
}