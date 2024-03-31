namespace EventSourcing.Domain;

public record Event
{
    public DateTimeOffset CreatedAt { get; }

    protected Event()
    {
        CreatedAt = DateTimeOffset.Now;
    }
}