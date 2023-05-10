namespace MRT.Data.FormModels;

public class Location
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Address { get; set; }

    public ResultModels.Location ToRecord()
    {
        return new ResultModels.Location()
        {
            Id = Guid.NewGuid(),
            Name = Name,
            Description = Description,
            Address = Address
        };
    }
}