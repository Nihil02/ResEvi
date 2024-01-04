using System.Collections.Generic;
using ResEvi.Contracts;

namespace ResEvi.Data.Entities
{
    internal sealed class Company : IEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public Sector Sector { get; set; }
        public string RFC { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public IList<Contact> Contacts { get; set; }
        public IList<Advisor> Advisors { get; set; }
        public IList<Project> Projects { get; set; }
    }
}
