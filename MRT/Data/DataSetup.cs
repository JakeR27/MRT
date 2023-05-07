using MRT.Data.ResultModels;

namespace MRT.Data;

public class DataSetup
{
    public static void Set()
    {
        var db = LiteDb.Instance().Database;
        
        var c100 = new Organiser {Id = Guid.NewGuid(), Name = "Club 100"};
        var lms = new Organiser {Id = Guid.NewGuid(), Name = "Leeds Motorsport Society"};
        PersistService.AddOrganiser(c100);
        PersistService.AddOrganiser(lms);


        var bukc2021 = new Championship
        {
            Id = Guid.NewGuid(),
            Name = "BUKC",
            StartDate = new DateTime(2021, 09, 01),
            EndDate = new DateTime(2022, 04, 01),
            ChampionshipOrganiser = c100
        };
        var bukc2022 = new Championship
        {
            Id = Guid.NewGuid(),
            Name = "BUKC",
            StartDate = new DateTime(2022, 09, 01),
            EndDate = new DateTime(2023, 04, 01),
            ChampionshipOrganiser = c100
        };
        PersistService.AddChampionship(bukc2021);
        PersistService.AddChampionship(bukc2022);

        
        var tdy2021 = new Championship
        {
            Id = Guid.NewGuid(),
            Name = "TDY",
            StartDate = new DateTime(2021, 09, 01),
            EndDate = new DateTime(2022, 04, 01),
            ChampionshipOrganiser = lms
        };
        var tdy2022 = new Championship
        {
            Id = Guid.NewGuid(),
            Name = "TDY",
            StartDate = new DateTime(2022, 09, 01),
            EndDate = new DateTime(2023, 04, 01),
            ChampionshipOrganiser = lms
        };
        PersistService.AddChampionship(tdy2021);
        PersistService.AddChampionship(tdy2022);
        
        var whilton = new Location {Id = Guid.NewGuid(), Name = "Whilton Mill", Address = "NN11 2NH"};
        var pfi = new Location {Id= Guid.NewGuid(), Name = "PFI", Address = "NG32 2AY"};
        var clay = new Location {Id = Guid.NewGuid(), Name = "Clay Pigeon", Address = "DT2 9PW"};
        var buckmore = new Location {Id = Guid.NewGuid(), Name = "Buckmore Park", Address = "ME5 9QG"};
        var gyg = new Location {Id= Guid.NewGuid(), Name = "Glan Y Gors", Address = "LL11 6YA"};
        PersistService.AddLocation(clay);
        PersistService.AddLocation(buckmore);
        PersistService.AddLocation(pfi);
        PersistService.AddLocation(whilton);
        PersistService.AddLocation(gyg);
        
        var bukc2022q = new Event
        {
            Id = Guid.NewGuid(),
            Name = "Saturday Qualifiers",
            StartDate = new DateTime(2022, 11, 19),
            EndDate = new DateTime(2022, 11, 19),
            Championship = bukc2022,
            Location = whilton
        };
        PersistService.AddEvent(bukc2022q);
        
        var bukc2022r1m = new Event
        {
            Id = Guid.NewGuid(),
            Name = "Mains - Round 1",
            StartDate = new DateTime(2022, 11, 19),
            EndDate = new DateTime(2022, 11, 19),
            Championship = bukc2022,
            Location = buckmore
        };
        PersistService.AddEvent(bukc2022r1m);
        
        var bukc2022r2m = new Event
        {
            Id = Guid.NewGuid(),
            Name = "Mains - Round 2",
            StartDate = new DateTime(2022, 11, 19),
            EndDate = new DateTime(2022, 11, 19),
            Championship = bukc2022,
            Location = buckmore
        };
        PersistService.AddEvent(bukc2022r2m);
        
        var bukc2022r3m = new Event
        {
            Id = Guid.NewGuid(),
            Name = "Mains - Round 3",
            StartDate = new DateTime(2022, 11, 19),
            EndDate = new DateTime(2022, 11, 19),
            Championship = bukc2022,
            Location = pfi
        };
        PersistService.AddEvent(bukc2022r3m);
        
        var bukc2022r4m = new Event
        {
            Id = Guid.NewGuid(),
            Name = "Mains - Round 4",
            StartDate = new DateTime(2022, 11, 19),
            EndDate = new DateTime(2022, 11, 19),
            Championship = bukc2022,
            Location = pfi
        };
        PersistService.AddEvent(bukc2022r4m);
        
        var bukc2022r5m = new Event
        {
            Id = Guid.NewGuid(),
            Name = "Mains - Round 5",
            StartDate = new DateTime(2022, 11, 19),
            EndDate = new DateTime(2022, 11, 19),
            Championship = bukc2022,
            Location = gyg
        };
        PersistService.AddEvent(bukc2022r5m);
        
        var bukc2022r6m = new Event
        {
            Id = Guid.NewGuid(),
            Name = "Mains - Round 6",
            StartDate = new DateTime(2022, 11, 19),
            EndDate = new DateTime(2022, 11, 19),
            Championship = bukc2022,
            Location = gyg
        };
        PersistService.AddEvent(bukc2022r6m);
        
    }
}