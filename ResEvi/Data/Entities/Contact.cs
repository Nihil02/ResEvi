namespace ResEvi.Data.Entities
{
    internal sealed class Contact
    {
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public Company Company { get; set; }
        public string Phone { get; set; }
        public string Extension { get; set; }
        public string Email { get; set; }
    }
}
