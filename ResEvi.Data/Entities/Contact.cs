namespace ResEvi.Data.Entities;

public sealed class Contact
{
    public long Id { get; set; }
    public Adviser Adviser { get; set; } = new Adviser();
    public ContactType Type { get; set; }
    public string Value { get; set; } = "";
    public string Extra { get; set; } = "";
}

public enum ContactType
{
    Otro,
    Email,
    Telefono,
}
