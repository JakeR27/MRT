namespace MRT.Data.ResultModels
{
    public record Championship
    {
        public Guid Id{ get; init; }
        public string Name { get; init; }
        public DateTime StartDate { get; init; }
        public DateTime EndDate { get; init; }

        public Organiser? ChampionshipOrganiser {get; init; }

    }
}
