namespace ResEvi.Data.Entities
{
    internal sealed class Student
    {
        public long Id { get; set; }
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public Specialty Specialty { get; set; } = new Specialty();
        public Gender Gender { get; set; }
        public string Semester { get; set; } = "";
        public DateTime RegisterDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Company Company { get; set; } = new Company();
        public string Department { get; set; } = "";
        public string Schedule { get; set; } = "";
        public bool IsActive { get; set; }
        public string Notes { get; set; } = "";
    }

    internal enum Gender
    {
        Other,
        Female,
        Male,
    }
}
