namespace MRT.Data.ResultModels
{
    public record Location
    {
        public Guid Id {get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
    }
}
