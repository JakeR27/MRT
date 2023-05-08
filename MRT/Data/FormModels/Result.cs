namespace MRT.Data.FormModels;

public class Result
{
    public int StartPosition { get; set; }
    public int FinishOnTrackPosition { get; set; }
    public int FinishOnResultPosition { get; set; }
    public Guid RaceId { get; set; }
    public Guid CompetitorId { get; set; }
    public Guid TeamId { get; set; }
    
    public ResultModels.Result ToRecord()
    {
        return new ResultModels.Result()
        {
            Id = Guid.NewGuid(),
            StartPosition = StartPosition,
            FinishOnTrackPosition = FinishOnTrackPosition,
            FinishOnResultPosition = FinishOnResultPosition,
            Race = PersistService.GetRaceById(RaceId),
            Competitor = PersistService.GetCompetitorById(CompetitorId),
            Team = PersistService.GetTeamById(TeamId)
        };
    }
}