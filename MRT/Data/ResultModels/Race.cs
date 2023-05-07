namespace MRT.Data.ResultModels;

public record Race
{
    public Guid Id { get; init; }
    private Guid EventId { get; init; }
    public Event Event { 
        get => PersistService.GetEventById(EventId);
        init => EventId = value.Id; 
    }
    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }
}