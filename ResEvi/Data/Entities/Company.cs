namespace ResEvi.Data.Entities
{
    internal sealed class Company
    {
        public long Id { get; set; }
        public string Name { get; set; } = "";
        public string Rfc { get; set; } = "";
        public CompanyType Type { get; set; }
        public string Address { get; set; } = "";
        public int Postcode { get; set; }
        public string Locality { get; set; } = "";
        public string City { get; set; } = "";
        public string Region { get; set; } = "";
        public string Country { get; set; } = "";
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }

    internal enum CompanyType
    {
        Publica,
        Privada,
        Industrial,
    }
}
