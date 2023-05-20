namespace MRT.Data.ResultModels
{
    public record Location : IModel
    {
        public Guid Id {get; init; }
        public string Name { get; init; }
        public string? Description { get; init; }
        public string? Address { get; init; }
    }
}
