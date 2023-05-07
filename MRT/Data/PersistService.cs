using MRT.Data.ResultModels;

namespace MRT.Data;

public class PersistService
{

    private static readonly List<Organiser> _organisers = new();
    private static readonly List<Championship> _championships = new();
    private static readonly List<Location> _locations = new();
    private static readonly List<Event> _events = new();

    public static List<Organiser> Organisers => _organisers;
    public static List<Championship> Championships => _championships;
    public static List<Location> Locations => _locations;
    public static List<Event> Events => _events;
    
    public static bool AddOrganiser(Organiser? organiser)
    {
        if (organiser == null) return false;

        LiteDb.Instance().Database.GetCollection<Organiser>("organiser").Insert(organiser);
        _organisers.Add(organiser);
        return true;
    }
    
    public static bool AddChampionship(Championship? championship)
    {
        if (championship == null) return false;

        LiteDb.Instance().Database.GetCollection<Championship>("championship").Insert(championship);
        _championships.Add(championship);
        return true;
    }
    
    public static bool AddLocation(Location? location)
    {
        if (location == null) return false;

        LiteDb.Instance().Database.GetCollection<Location>("location").Insert(location);
        _locations.Add(location);
        return true;
    }
    
    public static bool AddEvent(Event? ev)
    {
        if (ev == null) return false;

        LiteDb.Instance().Database.GetCollection<Event>("event").Insert(ev);
        _events.Add(ev);
        return true;
    }

    public static Organiser? GetOrganiserById(Guid? championshipOrganiserId)
    {
        if (championshipOrganiserId == null) return null;
        
        //load from db
        return LiteDb.Instance().Database
            .GetCollection<Organiser>("organiser")
            .FindOne(organiser => organiser.Id == championshipOrganiserId);
    }
    
    public static Championship GetChampionshipById(Guid championshipId)
    {
        return LiteDb.Instance().Database
            .GetCollection<Championship>("championship")
            .FindOne(championship => championship.Id == championshipId);
    }
    
    public static Event GetEventById(Guid eventId)
    {
        return LiteDb.Instance().Database
            .GetCollection<Event>("event")
            .FindOne(ev => ev.Id == eventId);
    }
    
    public static Competitor GetCompetitorById(Guid competitorId)
    {
        return LiteDb.Instance().Database
            .GetCollection<Competitor>("competitor")
            .FindOne(competitor => competitor.Id == competitorId);
    }
    
    public static Team GetTeamById(Guid teamId)
    {
        return LiteDb.Instance().Database
            .GetCollection<Team>("team")
            .FindOne(team => team.Id == teamId);
    }
    
    public static Location GetLocationById(Guid locationId)
    {
        //if (locationId == null) return null;
        
        //load from db
        return LiteDb.Instance().Database
            .GetCollection<Location>("location")
            .FindOne(location => location.Id == locationId);
    }
}