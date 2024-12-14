namespace Domain.Models;

public class Purchase
{
// #### **`Purchases` (Покупки)**  
// - `PurchaseId` (int, PK) — уникальный идентификатор покупки.  
// - `TicketId` (int, FK → Tickets.TicketId) — идентификатор билета.  
// - `CustomerId` (int, FK → Customers.CustomerId) — идентификатор покупателя.  
// - `PurchaseDateTime` (timestamp) — дата и время покупки.  
// - `Quantity` (int) — количество билетов.  
// - `TotalPrice` (decimal(10, 2)) — общая стоимость покупки. 
    public int PurchaseId { get; set; }
    public int TicketId { get; set; }
    public int CustomerId { get; set; }
    public DateTime PurchaseDateTime { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
    
}