namespace MRT.Data.ResultModels
{
    public record Event
    {
        public Guid Id { get; init; }
        public string? Name { get; init; }
        private Guid LocationId { get; init; }
        public Location Location { 
            get => PersistService.GetLocationById(LocationId);
            init => LocationId = value.Id;
        }
        private Guid ChampionshipId { get; init; }
        public Championship Championship { 
            get => PersistService.GetChampionshipById(ChampionshipId);
            init => ChampionshipId = value.Id;
        }
        public DateTime StartDate { get; init; }
        public DateTime EndDate { get; init; }

    }
}
