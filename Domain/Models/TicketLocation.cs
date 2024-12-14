namespace Domain.Models;

public class TicketLocation
{
// #### **`TicketLocations` (Привязка билетов к местам)**  
// - `TicketId` (int, FK → Tickets.TicketId) — идентификатор билета.  
// - `LocationId` (int, FK → Locations.LocationId) — идентификатор места. 
    public int TicketId { get; set; }
    public int LocationId { get; set; }

}
