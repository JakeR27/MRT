using Microsoft.AspNetCore;

namespace MRT.Data.ResultModels
{
    public record Championship
    {
        public Guid Id{ get; init; }
        public string Name { get; init; }
        public DateTime StartDate { get; init; }
        public DateTime EndDate { get; init; }

        private Guid? ChampionshipOrganiserId { get; init; }
        public Organiser? ChampionshipOrganiser 
        {
            get => PersistService.GetOrganiserById(ChampionshipOrganiserId);
            init => ChampionshipOrganiserId = value?.Id;
        }

    }
}
