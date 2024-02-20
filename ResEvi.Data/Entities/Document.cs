namespace ResEvi.Data.Entities;

public sealed class Document
{
    public long Id { get; set; }
    public Student Student { get; set; } = new Student();
    public DocumentType Type { get; set; }
    public string Name { get; set; } = "";
}

public enum DocumentType
{
    Other,
    Draft,
    SocialServiceCertificate,
    ResidencyApplication,
    LetterOfIntroduction,
    LetterOfAcceptance,
}
