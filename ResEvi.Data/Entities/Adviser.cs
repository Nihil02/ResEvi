namespace ResEvi.Data.Entities;

public sealed class Adviser
{
    public long Id { get; set; }
    public Company Company { get; set; } = new Company();
    public string Department { get; set; } = "";
    public string Type { get; set; } = "";
    public string Name { get; set; } = "";
    public string Role { get; set; } = "";
}
