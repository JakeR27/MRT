using MRT.Data.ResultModels;

namespace MRT.Data;

public class ResultsService
{
    private static readonly Organiser[] _organisers = new[]
    {
        new Organiser { Id = Guid.NewGuid(), Name = "Club 100" }
    };

    private static readonly Championship[] _championships = new[]
    {
        new Championship
        {
            Id = Guid.NewGuid(),
            Name = "BUKC",
            StartDate = new DateTime(2022, 09, 01),
            EndDate = new DateTime(2023, 04, 01),
            ChampionshipOrganiser = _organisers[0]
        }
    };
    
    public Task<Championship[]> GetChampionshipsAsync()
    {
        return Task.FromResult(_championships);
    }
}