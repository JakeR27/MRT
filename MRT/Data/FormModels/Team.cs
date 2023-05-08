namespace MRT.Data.FormModels;

public class Team
{
    public string Name { get; set; }
    public ResultModels.Team ToRecord()
    {
        return new ResultModels.Team()
        {
            Id = Guid.NewGuid(),
            Name = Name
        };
    }
}