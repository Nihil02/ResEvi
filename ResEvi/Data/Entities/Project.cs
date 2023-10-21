namespace ResEvi.Data.Entities
{
    internal sealed class Project
    {
        public long Id { get; set; }
        public Company Company { get; set; }
        public string Name { get; set; }
    }
}
