namespace MRT.Data.FormModels;

public class Event
{
    public string Name { get; set; }
    public Guid LocationId { get; set; }
    public Guid ChampionshipId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public Data.ResultModels.Event ToRecord()
    {
        return new ResultModels.Event()
        {
            Id = Guid.NewGuid(),
            Championship = PersistService.GetChampionshipById(ChampionshipId),
            Location = PersistService.GetLocationById(LocationId),
            StartDate = StartDate,
            EndDate = EndDate,
            Name = Name
        };
    }
    public Data.ResultModels.Event ToRecord(Guid id)
    {
        return new ResultModels.Event()
        {
            Id = id,
            Championship = PersistService.GetChampionshipById(ChampionshipId),
            Location = PersistService.GetLocationById(LocationId),
            StartDate = StartDate,
            EndDate = EndDate,
            Name = Name
        };
    }
}