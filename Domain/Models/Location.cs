namespace Domain.Models;

public class Location
{
// #### **`Locations` (Места)**  
// - `LocationId` (int, PK) — уникальный идентификатор места.  
// - `City` (varchar, 100) — город.  
// - `Address` (varchar, 200) — адрес.  
// - `LocationType` (varchar, 50) — тип места (например, "Airport", "Railway Station", "Event Hall").  
    public int LocationId { get; set; }
    public string City { get; set; }
    public string Address { get; set; }
    public string LocationType { get; set; }

}