namespace MRT.Data.FormModels;

public class Competitor
{
    public string Name { get; set; }

    public ResultModels.Competitor ToRecord()
    {
        return new ResultModels.Competitor()
        {
            Id = Guid.NewGuid(),
            Name = Name
        };
    }
}

