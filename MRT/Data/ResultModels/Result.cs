namespace MRT.Data.ResultModels;

public record Result
{
    public Guid Id { get; init; }
    public int StartPosition { get; init; }
    public int FinishOnTrackPosition { get; init; }
    public int FinishOnResultPosition { get; init; }
    public List<Penalty> PenaltiesReceived { get; init; }
    
    private Guid CompetitorId { get; init; }
    public Competitor Competitor { 
        get => PersistService.GetCompetitorById(CompetitorId);
        init => CompetitorId = value.Id;
    }
    private Guid TeamID { get; init; }
    public Team Team
    {
        get => PersistService.GetTeamById(TeamID);
        init => TeamID = value.Id;
    }
}