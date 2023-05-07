namespace MRT.Data.ResultModels
{
    public record Event
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Location Location { get; set; }
        public Championship Championship { get; set; }
        public DateTime Date{ get; set; }

    }
}
