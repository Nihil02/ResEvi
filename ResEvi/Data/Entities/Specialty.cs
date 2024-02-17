namespace ResEvi.Data.Entities
{
    internal sealed class Specialty
    {
        public long Id { get; set; }
        public Career Career { get; set; } = new Career();
        public string Name { get; set; } = "";
        public bool IsActive { get; set; }
    }
}
