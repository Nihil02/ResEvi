namespace ResEvi.Data.Entities
{
    internal sealed class Document
    {
        public long Id { get; set; }
        public Student Student { get; set; } = new Student();
        public DocumentType Type { get; set; }
        public string Name { get; set; } = "";
    }

    internal enum DocumentType
    {
        Other,
        Draft,
        SocialServiceCertificate,
        ResidencyApplication,
        LetterOfIntroduction,
        LetterOfAcceptance,
    }
}
