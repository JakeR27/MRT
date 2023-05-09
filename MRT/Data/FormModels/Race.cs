namespace MRT.Data.FormModels;

public class Race
{
    public Guid EventId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public ResultModels.Race ToRecord()
    {
        return new ResultModels.Race()
        {
            Id = Guid.NewGuid(),
            Event = PersistService.GetEventById(EventId),
            StartDate = StartDate,
            EndDate = EndDate,
            Name = Name,
            Description = Description
        };
    }
}