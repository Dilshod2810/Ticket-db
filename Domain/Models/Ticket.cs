namespace Domain.Models;

public class Ticket
{
// #### **`Tickets` (Билеты)**  
// - `TicketId` (int, PK) — уникальный идентификатор билета.  
// - `Type` (varchar, 50) — тип билета (например, "Flight", "Train", "Bus", "Event").  
// - `Title` (varchar, 150) — описание билета (например, "Рейс Москва - Нью-Йорк").  
// - `Price` (decimal(10, 2)) — стоимость билета.  
// - `EventDateTime` (timestamp) — дата и время отправления или проведения.  
    public int TicketId { get; set; }
    public string Type { get; set; }
    public string Title { get; set; }
    public decimal Price { get; set; }
    public DateTime EventDateTime { get; set; }
}