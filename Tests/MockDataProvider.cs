using ResEvi.Data.Entities;
using Record = ResEvi.Data.Entities.Record;

namespace Tests.Data
{
    internal class MockDataProvider
    {
        public static List<Advisor> fakeAdvisors 
        {
            get 
            {
                return new List<Advisor>
                {
                    new() {Id = 1, CompanyId = 1, Type = "Yes", Department = "Sistemas", Email = "foo@example.com", Name = "Bar", Position = "Jefe", Phone = "8331111111"},
                };
            }
        }

        public static List<Company> fakeCompanies
        {
            get
            {
                return new List<Company>
                {
                    new() {},
                    new() {},
                };
            }
        }

        public static List<Contact> fakeContacts
        {
            get
            {
                return new List<Contact>
                {
                    new() {},
                };
            }
        }

        public static List<Project> fakeProjects
        {
            get
            {
                return new List<Project>
                {
                    new () {},
                };
            }
        }

        public static List<Record> fakeRecords
        {
            get
            {
                return new List<Record>
                {
                    new Record() {},
                };
            }
        }
    }
}
