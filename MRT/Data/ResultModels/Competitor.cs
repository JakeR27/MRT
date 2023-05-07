namespace MRT.Data.ResultModels
{
    public record Competitor
    {
        public Guid Id {get; init; }
        public string? Name { get; init; }
    }
}
