using System;

namespace ResEvi.Data.Entities
{
    internal sealed class Record
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Major { get; set; }
        public string Specialty { get; set; }
        public Gender Gender { get; set; }
        public string Period { get; set; }
        public string Department { get; set; }
        public Project Project { get; set; }
        public string Module { get; set; }
        public Advisor Reviewer { get; set; }
        public Advisor InternalAdvisor { get; set; }
        public Advisor ExternalAdvisor { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Schedule { get; set; }
        public bool HasInternshipRequest { get; set; }
        public bool HasPresentationLetter { get; set; }
        public bool HasAcceptanceLetter { get; set; }
        public bool HasProofOfSocialService { get; set; }
        public bool HasPreProject { get; set; }
        public bool IsRecordClosed { get; set; }
        public string Observations { get; set; }
    }
}
