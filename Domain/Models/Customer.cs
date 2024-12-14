namespace Domain.Models;

public class Customer
{
// #### **`Customers` (Покупатели)**  
// - `CustomerId` (int, PK) — уникальный идентификатор покупателя.  
// - `FullName` (varchar, 150) — полное имя покупателя.  
// - `Email` (varchar, 150) — электронная почта.  
// - `Phone` (varchar, 20) — номер телефона.  
    public int  CustomerId { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}