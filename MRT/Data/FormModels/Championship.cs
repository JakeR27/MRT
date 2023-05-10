namespace MRT.Data.FormModels;

public class Championship
{
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Guid ChampionshipOrganiserId { get; set; }

    public Data.ResultModels.Championship ToRecord()
    {
        return new ResultModels.Championship()
        {
            Id = Guid.NewGuid(),
            Name = Name,
            StartDate = StartDate,
            EndDate = EndDate,
            ChampionshipOrganiser = PersistService.GetOrganiserById(ChampionshipOrganiserId),
        };
    }
}