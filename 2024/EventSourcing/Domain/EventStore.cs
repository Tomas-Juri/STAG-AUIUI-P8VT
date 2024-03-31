using System.Text.Json;
using EventSourcing.Database;
using EventSourcing.Database.Models;

namespace EventSourcing.Domain;

public class EventStore(DataContext dataContext)
{
    public ApplicationState GetState() =>
        dataContext
            .Events
            .ToList()
            .Select(@event => JsonSerializer.Deserialize(@event.Data, Type.GetType(@event.AssemblyTypeName)))
            .Cast<Event>()
            .Aggregate(ApplicationState.Empty, ApplicationState.Apply);

    public void Add(Event @event)
    {
        var type = @event.GetType();
        dataContext.Events.Add(new EventDo
        {
            Name = type.Name,
            AssemblyTypeName = type.AssemblyQualifiedName!,
            Data = JsonSerializer.Serialize(@event, type)
        });
        dataContext.SaveChanges();
    }
}