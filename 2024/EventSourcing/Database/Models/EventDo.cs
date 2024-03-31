namespace EventSourcing.Database.Models;

public class EventDo
{
    public Guid Id { get; set; }
    
    public required string Name { get; set; }
    
    public required string Data { get; set; }
    
    public required string AssemblyTypeName { get; set; }
}