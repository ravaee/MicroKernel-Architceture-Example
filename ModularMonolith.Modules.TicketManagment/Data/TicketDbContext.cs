using Microsoft.EntityFrameworkCore;
using ModularMonolith.Modules.TicketManagment.Domain.Models;

namespace ModularMonolith.Modules.TicketManagment.Data;

public class TicketDbContext(DbContextOptions<TicketDbContext> options) : DbContext(options)
{
    public required DbSet<Ticket> Tickets { get; init; }
}
