using MRT.Data.ResultModels;

namespace MRT.Data;

public class ResultsService
{
    private static Organiser[] _organisers => PersistService.Organisers.ToArray();
    //     = new[]
    // {
    //     new Organiser { Id = Guid.NewGuid(), Name = "Club 100" },
    //     new Organiser { Id = Guid.NewGuid(), Name = "Leeds Motorsport Society" }
    // };

    private static Championship[] _championships = PersistService.Championships.ToArray();
    //     = new[]
    // {
    //     new Championship
    //     {
    //         Id = Guid.NewGuid(),
    //         Name = "BUKC",
    //         StartDate = new DateTime(2021, 09, 01),
    //         EndDate = new DateTime(2022, 04, 01),
    //         ChampionshipOrganiser = _organisers[0]
    //     },
    //     new Championship
    //     {
    //         Id = Guid.NewGuid(),
    //         Name = "BUKC",
    //         StartDate = new DateTime(2022, 09, 01),
    //         EndDate = new DateTime(2023, 04, 01),
    //         ChampionshipOrganiser = _organisers[0]
    //     },
    //     new Championship
    //     {
    //         Id = Guid.NewGuid(),
    //         Name = "TDY",
    //         StartDate = new DateTime(2021, 09, 01),
    //         EndDate = new DateTime(2022, 04, 01),
    //         ChampionshipOrganiser = _organisers[1]
    //     },
    //     new Championship
    //     {
    //         Id = Guid.NewGuid(),
    //         Name = "TDY",
    //         StartDate = new DateTime(2022, 09, 01),
    //         EndDate = new DateTime(2023, 04, 01),
    //         ChampionshipOrganiser = _organisers[1]
    //     }
    //     
    // };

    private static Location[] _locations => PersistService.Locations.ToArray();
    //     = new[]
    // {
    //     new Location
    //     {
    //         Id = Guid.NewGuid(),
    //         Name = "Whilton Mill",
    //         Address = "NN11 2NH"
    //     }
    // };

    private static Event[] _events => PersistService.Events.ToArray();
    //     = new[]
    // {
    //     new Event
    //     {
    //         Id = Guid.NewGuid(),
    //         Championship = _championships[0],
    //         StartDate = new DateTime(2022, 11, 19),
    //         EndDate = new DateTime(2022, 11, 19),
    //         Location = _locations[0],
    //         Name = "Saturday Qualifiers"
    //     }
    // };
    private static Race[] _races => PersistService.Races.ToArray();
    private static Result[] _results => PersistService.Results.ToArray();
    private static Competitor[] _competitors => PersistService.Competitors.ToArray();
    
    private static Team[] _teams => PersistService.Teams.ToArray();
    
    public Task<Championship[]> GetChampionshipsAsync()
    {
        return Task.FromResult(_championships);
    }

    public Task<Championship[]> GetChampionshipsAsync(Organiser? organiser)
    {
        if (organiser == null || organiser.Id == Guid.Empty)
        {
            return GetChampionshipsAsync();
        }
        return Task.FromResult(
            _championships.Where(championship =>
                championship.ChampionshipOrganiser?.Id == organiser.Id
            ).ToArray()
        );
    }
    
    public Task<Organiser[]> GetOrganisersAsync()
    {
        return Task.FromResult(_organisers);
    }
    
    public Task<Organiser?> GetOrganiserAsync(Guid id)
    {
        return Task.FromResult(_organisers.FirstOrDefault(organiser => organiser.Id == id));
    }
    
    public Task<Championship?> GetChampionshipAsync(Guid id)
    {
        return Task.FromResult(_championships.FirstOrDefault(championship => championship.Id == id));
    }
    
    public Task<Location?> GetLocationAsync(Guid id)
    {
        return Task.FromResult(_locations.FirstOrDefault(location => location.Id == id));
    }
    
    public Task<Competitor[]> GetCompetitorsAsync()
    {
        return Task.FromResult(_competitors);
    }
    
    public Task<Event?> GetEventAsync(Guid id)
    {
        return Task.FromResult(_events.FirstOrDefault(ev => ev.Id == id));
    }
    public Task<Event[]> GetEventsAsync()
    {
        return Task.FromResult(_events);
    }
    public Task<Event[]> GetEventsAsync(Championship? championship)
    {
        if (championship == null || championship.Id == Guid.Empty)
        {
            return GetEventsAsync();
        }
        
        return Task.FromResult(_events.Where(ev => ev.Championship.Id == championship.Id).ToArray());
    }
    
    public Task<Event[]> GetEventsAsync(Location? location)
    {
        if (location == null || location.Id == Guid.Empty)
        {
            return GetEventsAsync();
        }
        
        return Task.FromResult(_events.Where(ev => ev.Location.Id == location.Id).ToArray());
    }

    public Task<Event[]> GetEventsAsync(Championship? championship, Location? location)
    {
        if (championship == null || championship.Id == Guid.Empty)
        {
            return GetEventsAsync(location);
        }

        if (location == null || location.Id == Guid.Empty)
        {
            return GetEventsAsync(championship);
        }
        
        return Task.FromResult(_events.Where(ev => ev.Championship.Id == championship.Id && ev.Location.Id == location.Id).ToArray());
    }
    
    public Task<Result[]> GetResultsAsync(Competitor competitor)
    {
        return Task.FromResult(_results.Where(result => result.Competitor.Id == competitor.Id).ToArray());
    }

    public Task<Result[]> GetResultsAsync(Event ev)
    {
        return Task.FromResult(_results.Where(result => result.Race.Event.Id == ev.Id).ToArray());
    }

    public Task<Result[]> GetResultsAsync(Race? race)
    {
        if (race == null || race.Id == Guid.Empty)
        {
            return Task.FromResult(_results);
        }
        
        return Task.FromResult(_results.Where(result => result.Race.Id == race.Id).ToArray());
    }
    
    public Task<Competitor?> GetCompetitorAsync(Guid id)
    {
        return Task.FromResult(_competitors.FirstOrDefault(competitor => competitor.Id == id));
    }
    
    public Task<Team[]> GetTeamsAsync(Competitor competitor)
    {
        var results = _results.Where(result => result.Competitor.Id == competitor.Id).ToList();
        var teams = results.Select(result => result.Team).Distinct().ToArray();
        return Task.FromResult(teams);
    }

    public Task<Race[]> GetRacesAsync()
    {
        return Task.FromResult(_races);
    }

    public Task<Race[]> GetRacesAsync(Event? ev)
    {
        if (ev == null || ev.Id == Guid.Empty)
        {
            return GetRacesAsync();
        }
        
        return Task.FromResult(_races.Where(race => race.EventId == ev.Id).ToArray());
    }
    
    public Task<Race?> GetRaceAsync(Guid id)
    {
        return Task.FromResult(_races.FirstOrDefault(race => race.Id == id));
    }
    
}