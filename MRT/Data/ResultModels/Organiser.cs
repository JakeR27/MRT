namespace MRT.Data.ResultModels
{
    public record Organiser : IModel
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
    }
}
