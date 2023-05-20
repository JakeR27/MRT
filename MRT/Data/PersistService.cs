using MRT.Data.ResultModels;

namespace MRT.Data;

public class PersistService
{

    private static readonly List<Organiser> _organisers = new();
    private static readonly List<Championship> _championships = new();
    private static readonly List<Location> _locations = new();
    private static readonly List<Event> _events = new();
    private static readonly List<Race> _races = new();
    private static readonly List<Result> _results = new();
    private static readonly List<Competitor> _competitors = new();
    private static readonly List<Team> _teams = new();

    public static List<Organiser> Organisers => _organisers;
    public static List<Championship> Championships => _championships;
    public static List<Location> Locations => _locations;
    public static List<Event> Events => _events;
    public static List<Race> Races => _races;
    public static List<Result> Results => _results;
    public static List<Competitor> Competitors => _competitors;
    public static List<Team> Teams => _teams;
    
    private static IDatabase _database;
    
    public PersistService(IDatabase database)
    {
        _database = database;
    }
    
    public static bool AddOrganiser(Organiser? organiser)
    {
        if (organiser == null) return false;

        _database.Insert(organiser, "organiser");
        //LiteDb.Instance().Database.GetCollection<Organiser>("organiser").Insert(organiser);
        _organisers.Add(organiser);
        return true;
    }
    
    public static bool AddChampionship(Championship? championship)
    {
        if (championship == null) return false;

        _database.Insert(championship, "championship");
        //LiteDb.Instance().Database.GetCollection<Championship>("championship").Insert(championship);
        _championships.Add(championship);
        return true;
    }
    
    public static bool AddLocation(Location? location)
    {
        if (location == null) return false;

        _database.Insert(location, "location");
        //LiteDb.Instance().Database.GetCollection<Location>("location").Insert(location);
        _locations.Add(location);
        return true;
    }
    
    public static bool AddEvent(Event? ev)
    {
        if (ev == null) return false;

        _database.Insert(ev, "event");
        //LiteDb.Instance().Database.GetCollection<Event>("event").Insert(ev);
        _events.Add(ev);
        return true;
    }

    public static bool AddRace(Race? race)
    {
        if (race == null) return false;

        _database.Insert(race, "race");
        //LiteDb.Instance().Database.GetCollection<Race>("race").Insert(race);
        _races.Add(race);
        return true;
    }
    
    public static bool AddResult(Result? result)
    {
        if (result == null) return false;

        _database.Insert(result, "result");
        //LiteDb.Instance().Database.GetCollection<Result>("result").Insert(result);
        _results.Add(result);
        return true;
    }

    public static bool AddCompetitor(Competitor? competitor)
    {
        if (competitor == null) return false;

        _database.Insert(competitor, "competitor");
        // LiteDb.Instance().Database.GetCollection<Competitor>("competitor").Insert(competitor);
        _competitors.Add(competitor);
        return true;
    }

    public static bool AddTeam(Team? team)
    {
        if (team == null) return false;

        _database.Insert(team, "team");
        //LiteDb.Instance().Database.GetCollection<Team>("team").Insert(team);
        _teams.Add(team);
        return true;
    }

    public static Organiser? GetOrganiserById(Guid? championshipOrganiserId)
    {
        return championshipOrganiserId == null ? null :
            //load from db
            _database.Get<Organiser>(championshipOrganiserId.Value, "organiser");

        return LiteDb.Instance().Database
            .GetCollection<Organiser>("organiser")
            .FindOne(organiser => organiser.Id == championshipOrganiserId);
    }
    
    public static Championship? GetChampionshipById(Guid? championshipId)
    {
        return championshipId == null ? null :
            _database.Get<Championship>(championshipId.Value, "championship");
        return LiteDb.Instance().Database
            .GetCollection<Championship>("championship")
            .FindOne(championship => championship.Id == championshipId);
    }
    
    public static Event? GetEventById(Guid? eventId)
    {
        return eventId == null ? null :
            _database.Get<Event>(eventId.Value, "event");

        return LiteDb.Instance().Database
            .GetCollection<Event>("event")
            .FindOne(ev => ev.Id == eventId);
    }
    
    public static Competitor? GetCompetitorById(Guid? competitorId)
    {
        return competitorId == null ? null :
            _database.Get<Competitor>(competitorId.Value, "competitor");
        return LiteDb.Instance().Database
            .GetCollection<Competitor>("competitor")
            .FindOne(competitor => competitor.Id == competitorId);
    }
    
    public static Team? GetTeamById(Guid? teamId)
    {
        return teamId == null ? null :
            _database.Get<Team>(teamId.Value, "team");
        return LiteDb.Instance().Database
            .GetCollection<Team>("team")
            .FindOne(team => team.Id == teamId);
    }

    public static Race? GetRaceById(Guid? raceId)
    {
        return raceId == null ? null :
            _database.Get<Race>(raceId.Value, "race");
        return LiteDb.Instance().Database
            .GetCollection<Race>("race")
            .FindOne(race => race.Id == raceId);
    }
    
    public static Location? GetLocationById(Guid? locationId)
    {
        return locationId == null ? null :
            _database.Get<Location>(locationId.Value, "location");
        //if (locationId == null) return null;
        
        //load from db
        return LiteDb.Instance().Database
            .GetCollection<Location>("location")
            .FindOne(location => location.Id == locationId);
    }

    public static bool UpdateResult(Result result)
    {
        if (result.Id == Guid.Empty) return false;
        
        LiteDb.Instance().Database.GetCollection<Result>("result").Update(result);
        LoadResults();
        return true;
    }
    public static bool UpdateEvent(Event ev)
    {
        if (ev.Id == Guid.Empty) return false;
        
        LiteDb.Instance().Database.GetCollection<Event>("event").Update(ev);
        LoadEvents();
        return true;
    } 

    public static void Load()
    {
        LoadOrganisers();
        LoadChampionships();
        LoadLocations();
        LoadEvents();
        LoadRaces();
        LoadResults();
        LoadCompetitors();
        LoadTeams();
        
    }
    
    public static void LoadOrganisers()
    {
        _organisers.AddRange(
            LiteDb.Instance().Database.GetCollection<Organiser>("organiser").FindAll().OrderBy(organiser => organiser.Name)
            );
    }
    
    public static void LoadChampionships()
    {
        _championships.AddRange(
            LiteDb.Instance().Database.GetCollection<Championship>("championship").FindAll().OrderBy(championship => championship.Year).ThenBy(championship => championship.Name)
            );
    }
    
    public static void LoadLocations()
    {
        _locations.AddRange(
            LiteDb.Instance().Database.GetCollection<Location>("location").FindAll().OrderBy(location => location.Name)
            );
    }
    
    public static void LoadEvents()
    {
        _events.Clear();
        _events.AddRange(
            LiteDb.Instance().Database.GetCollection<Event>("event").FindAll().OrderBy(ev => ev.StartDate).ThenBy(ev => ev.Name)
            );
    }
    
    public static void LoadResults()
    {
        _results.Clear();
        _results.AddRange(
            LiteDb.Instance().Database.GetCollection<Result>("result").FindAll()
        );
    }

    public static void LoadRaces()
    {
        _races.AddRange(
            LiteDb.Instance().Database.GetCollection<Race>("race").FindAll().OrderBy(race => race.Event.StartDate).ThenBy(race => race.Name)
            );
    }
    
    public static void LoadCompetitors()
    {
        _competitors.AddRange(
            LiteDb.Instance().Database.GetCollection<Competitor>("competitor").FindAll().OrderBy(competitor => competitor.Name)
            );
    }

    public static void LoadTeams()
    {
        _teams.AddRange(
            LiteDb.Instance().Database.GetCollection<Team>("team").FindAll().OrderBy(team => team.Name)
        );
    }
}