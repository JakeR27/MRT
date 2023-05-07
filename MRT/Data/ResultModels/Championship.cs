namespace MRT.Data.ResultModels
{
    public record Championship
    {
        public Guid Id{ get; set; }
        public string? Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Organiser? ChampionshipOrganiser {get; set; }

    }
}
