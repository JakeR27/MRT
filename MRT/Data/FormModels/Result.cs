namespace MRT.Data.FormModels;

public class Result
{
    public int StartPosition { get; set; }
    public int FinishOnTrackPosition { get; set; }
    public int FinishOnResultPosition { get; set; }
    public Guid RaceId { get; set; }
    public Guid CompetitorId { get; set; }
    public Guid TeamId { get; set; }
    public DateTime LapTime { get; set; }
    
    public ResultModels.Result ToRecord()
    {
        if (FinishOnResultPosition == 0)
        {
            FinishOnResultPosition = FinishOnTrackPosition;
        }
        return new ResultModels.Result()
        {
            Id = Guid.NewGuid(),
            StartPosition = StartPosition,
            FinishOnTrackPosition = FinishOnTrackPosition,
            FinishOnResultPosition = FinishOnResultPosition,
            Race = PersistService.GetRaceById(RaceId),
            Competitor = PersistService.GetCompetitorById(CompetitorId),
            Team = PersistService.GetTeamById(TeamId),
            LapTime = LapTime
        };
    }
    public ResultModels.Result ToRecord(Guid id)
    {
        if (FinishOnResultPosition == 0)
        {
            FinishOnResultPosition = FinishOnTrackPosition;
        }
        return new ResultModels.Result()
        {
            Id = id,
            StartPosition = StartPosition,
            FinishOnTrackPosition = FinishOnTrackPosition,
            FinishOnResultPosition = FinishOnResultPosition,
            Race = PersistService.GetRaceById(RaceId),
            Competitor = PersistService.GetCompetitorById(CompetitorId),
            Team = PersistService.GetTeamById(TeamId),
            LapTime = LapTime
        };
    }
}