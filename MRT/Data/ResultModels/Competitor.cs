namespace MRT.Data.ResultModels
{
    public record Competitor : IModel
    {
        public Guid Id {get; init; }
        public string? Name { get; init; }
    }
}
