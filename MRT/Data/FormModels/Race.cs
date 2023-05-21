namespace MRT.Data.FormModels;

public class Race
{
    public Guid EventId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int IndividualPointsOffered { get; set; } = 0;
    public int TeamPointsOffered { get; set; } = 0;

    public ResultModels.Race ToRecord()
    {
        return new ResultModels.Race()
        {
            Id = Guid.NewGuid(),
            Event = PersistService.GetEventById(EventId),
            StartDate = StartDate,
            EndDate = EndDate,
            Name = Name,
            Description = Description,
            IndividualPointsOffered = IndividualPointsOffered,
            TeamPointsOffered = TeamPointsOffered
        };
    }
    public ResultModels.Race ToRecord(Guid id)
    {
        return new ResultModels.Race()
        {
            Id = id,
            Event = PersistService.GetEventById(EventId),
            StartDate = StartDate,
            EndDate = EndDate,
            Name = Name,
            Description = Description,
            IndividualPointsOffered = IndividualPointsOffered,
            TeamPointsOffered = TeamPointsOffered
        };
    }
}