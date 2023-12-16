using System.Collections.Generic;

namespace ResEvi.Data.Entities
{
    internal sealed class Advisor
    {
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public Company Company { get; set; }
        public string Department { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public IList<Record> ReviewerRecords { get; set; }

        public IList<Record> InternalAdvisorRecords { get; set; }

        public IList<Record> ExternalAdvisorRecords { get; set; }
    }
}
