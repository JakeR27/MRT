using LiteDB;

namespace MRT.Data.ResultModels;

public record Result
{
    public Guid Id { get; init; }
    public int StartPosition { get; init; }
    public int FinishOnTrackPosition { get; init; }
    public int FinishOnResultPosition { get; init; }
    public DateTime? LapTime { get; set; }
    public List<Penalty> PenaltiesReceived { get; init; }
    public Guid RaceId { get; init; }
    [BsonIgnore]

    public Race Race
    {
        get => PersistService.GetRaceById(RaceId);
        init => RaceId = value.Id;
    }
    
    public Guid CompetitorId { get; init; }
    [BsonIgnore]
    public Competitor Competitor { 
        get => PersistService.GetCompetitorById(CompetitorId);
        init => CompetitorId = value.Id;
    }
    public Guid TeamId { get; init; }
    [BsonIgnore]
    public Team Team
    {
        get => PersistService.GetTeamById(TeamId);
        init => TeamId = value.Id;
    }
}