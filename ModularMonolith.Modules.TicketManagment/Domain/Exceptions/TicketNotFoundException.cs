namespace ModularMonolith.Modules.TicketManagment.Domain.Exceptions;

public class TicketNotFoundException : Exception
{
    public TicketNotFoundException(int ticketId)
        : base($"Ticket with Id {ticketId} not found.")
    {
    }
}
