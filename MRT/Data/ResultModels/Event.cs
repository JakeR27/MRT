namespace MRT.Data.ResultModels
{
    public record Event
    {
        public Guid Id { get; init; }
        public string? Name { get; init; }
        public Location Location { get; init; }
        public Championship Championship { get; init; }
        public DateTime StartDate { get; init; }
        public DateTime EndDate { get; init; }

    }
}
