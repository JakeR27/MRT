namespace MRT.Data.ResultModels;

public record Result
{
    public Guid Id { get; init; }
    public int StartPosition { get; init; }
    public int FinishOnTrackPosition { get; init; }
    public int FinishOnResultPosition { get; init; }
    public List<Penalty> PenaltiesReceived { get; init; }
    
    public Competitor Competitor { get; init; }
    public Team Team { get; init; }
}