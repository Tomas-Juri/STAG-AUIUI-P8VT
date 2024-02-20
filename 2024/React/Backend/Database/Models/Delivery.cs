namespace Application.Backend.Database.Models;

public class Delivery
{
    public Guid Id { get; set; }
    
    public string Location { get; set; }
    
    public Guid? UserId { get; set; }
    
    public User? User { get; set; }
}