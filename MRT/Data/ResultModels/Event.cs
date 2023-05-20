using LiteDB;

namespace MRT.Data.ResultModels
{
    public record Event : IModel
    {
        public Guid Id { get; init; }
        public string? Name { get; init; }
        public Guid LocationId { get; init; }
        [BsonIgnore]
        public Location Location { 
            get => PersistService.GetLocationById(LocationId);
            init => LocationId = value.Id;
        }
        public Guid ChampionshipId { get; init; }
        [BsonIgnore]
        public Championship Championship { 
            get => PersistService.GetChampionshipById(ChampionshipId);
            init => ChampionshipId = value.Id;
        }
        public DateTime StartDate { get; init; }
        public DateTime EndDate { get; init; }

    }
}
