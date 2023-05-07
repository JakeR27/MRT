namespace MRT.Data.ResultModels;

public record Penalty
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string? Description { get; init; }
    public float TimePenalty { get; init; }
    public int PositionPenalty { get; init; }
    public int LicencePenalty { get; init; }
}