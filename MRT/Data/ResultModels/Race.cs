using LiteDB;

namespace MRT.Data.ResultModels;

public record Race
{
    public Guid Id { get; init; }
    public Guid EventId { get; init; }
    [BsonIgnore]
    public Event Event { 
        get => PersistService.GetEventById(EventId);
        init => EventId = value.Id; 
    }
    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public int IndividualPointsOffered { get; init; } = 0;
    public int TeamPointsOffered { get; init; } = 0;
}