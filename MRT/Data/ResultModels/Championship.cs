using LiteDB;
using Microsoft.AspNetCore;

namespace MRT.Data.ResultModels
{
    public record Championship
    {
        public Guid Id{ get; init; }
        public string Name { get; init; }
        public DateTime StartDate { get; init; }
        public DateTime EndDate { get; init; }

        public Guid? ChampionshipOrganiserId { get; init; }
        [BsonIgnore]
        public Organiser? ChampionshipOrganiser 
        {
            get => PersistService.GetOrganiserById(ChampionshipOrganiserId);
            init => ChampionshipOrganiserId = value?.Id;
        }

        [BsonIgnore]
        public string Year => $"{StartDate.Year}/{EndDate.Year}";

    }
}
