namespace MRT.Data.ResultModels;

public record Race
{
    public Guid Id { get; init; }
    public Event Event { get; init; }
    public DateTime StartDate { get; init; }
    public DateTime EndDate { get; init; }
}