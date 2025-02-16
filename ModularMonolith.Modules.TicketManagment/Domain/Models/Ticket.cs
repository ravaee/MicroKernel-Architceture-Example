namespace ModularMonolith.Modules.TicketManagment.Domain.Models;

public class Ticket
{
    public int Id { get; set; }
    public string EventName { get; set; }
    public DateTime EventDate { get; set; }
}