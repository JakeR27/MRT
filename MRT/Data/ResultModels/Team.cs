namespace MRT.Data.ResultModels;

public record Team
{
    public Guid Id { get; init; }
    public string Name { get; init; }
}