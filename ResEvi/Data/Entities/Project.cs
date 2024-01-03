using ResEvi.Contracts;

namespace ResEvi.Data.Entities
{
    internal sealed class Project : IEntity
    {
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public long RecordId { get; set; }
        public Record Record { get; set; }
        public Company Company { get; set; }
        public string Name { get; set; }
    }
}
