using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ResEvi.Data.Entities
{
    internal sealed class AdvisorEntityTypeConfiguration: IEntityTypeConfiguration<Advisor>
    {
        public void Configure(EntityTypeBuilder<Advisor> builder)
        {
            builder.Property(advisor => advisor.Department).IsRequired();
            builder.Property(advisor => advisor.Type).IsRequired();
            builder.Property(advisor => advisor.Name).IsRequired();
            builder.Property(advisor => advisor.Position).IsRequired();
            builder.Property(advisor => advisor.Email).IsRequired();
            builder.Property(advisor => advisor.Phone).IsRequired();

            // Relationships

            // Advisor - Company
            builder.HasOne(advisor => advisor.Company)
                   .WithMany(company => company.Advisors)
                   .HasForeignKey(advisor => advisor.CompanyId);

            // Advisor - Dossier
            builder.HasMany(advisor => advisor.ReviewerRecords)
                   .WithOne(record => record.Reviewer)
                   .HasForeignKey(record => record.ReviewerId);

            builder.HasMany(advisor => advisor.InternalAdvisorRecords)
                   .WithOne(record => record.InternalAdvisor)
                   .HasForeignKey(record => record.InternalAdvisorId);

            builder.HasMany(advisor => advisor.ExternalAdvisorRecords)
                   .WithOne(record => record.ExternalAdvisor)
                   .HasForeignKey(record => record.ExternalAdvisorId);
        }
    }

    internal sealed class CompanyEntityTypeConfiguration: IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.Property(company => company.Name).IsRequired();
            builder.Property(company => company.Sector).IsRequired();
            builder.Property(company => company.RFC).IsRequired().HasMaxLength(12);
            builder.Property(company => company.Street).IsRequired();
            builder.Property(company => company.PostalCode).IsRequired();
            builder.Property(company => company.City).IsRequired();
            builder.Property(company => company.Country).IsRequired();

            // Relationships

            // Company - Contact
            builder.HasMany(company => company.Contacts)
                   .WithOne(contact => contact.Company)
                   .HasForeignKey(contact => contact.CompanyId);

            // Compnay - Advisor
            builder.HasMany(company => company.Advisors)
                   .WithOne(advisor => advisor.Company)
                   .HasForeignKey(advisor => advisor.CompanyId);

            // Company - Projects
            builder.HasMany(company => company.Projects)
                   .WithOne(project => project.Company)
                   .HasForeignKey(project => project.CompanyId);
        }
    }

    internal sealed class ContactEntityTypeConfiguration: IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(contact => contact.Phone).IsRequired();
            builder.Property(contact => contact.Extension).IsRequired();
            builder.Property(contact => contact.Email).IsRequired().HasAnnotation("RegularExpression", @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            // Relationships

            // Contact - Company
            builder.HasOne(contact => contact.Company)
                   .WithMany(company => company.Contacts)
                   .HasForeignKey(contact => contact.CompanyId);
        }
    }

    internal sealed class ProjectEntityTypeConfiguration: IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.Property(project => project.Name).IsRequired();

            // Relationships

            // Project - Company
            builder.HasOne(project => project.Company)
                   .WithMany(company => company.Projects)
                   .HasForeignKey(project => project.CompanyId);

            // Project - Record
            builder.HasOne(project => project.Record)
                   .WithOne(record => record.Project)
                   .HasForeignKey<Project>(project => project.RecordId);
        }
    }

    internal sealed class RecordEntityTypeConfiguration : IEntityTypeConfiguration<Record>
    {
        public void Configure(EntityTypeBuilder<Record> builder)
        { 
            builder.Property(record => record.Name).IsRequired();
            builder.Property(record => record.Email).IsRequired();
            builder.Property(record => record.Major).IsRequired();
            builder.Property(record => record.Specialty).IsRequired();
            builder.Property(record => record.Gender).IsRequired();
            builder.Property(record => record.Period).IsRequired();
            builder.Property(record => record.Department).IsRequired();
            builder.Property(record => record.Module).IsRequired();
            builder.Property(record => record.RegisterDate).IsRequired();
            builder.Property(record => record.StartDate).IsRequired();
            builder.Property(record => record.EndDate).IsRequired();
            builder.Property(record => record.Schedule).IsRequired();
            builder.Property(record => record.HasInternshipRequest).IsRequired();
            builder.Property(record => record.HasPresentationLetter).IsRequired();
            builder.Property(record => record.HasAcceptanceLetter).IsRequired();
            builder.Property(record => record.HasProofOfSocialService).IsRequired();
            builder.Property(record => record.HasPreProject).IsRequired();
            builder.Property(record => record.IsRecordClosed).IsRequired();
            builder.Property(record => record.Observations);
            
            // Relationships

            // Dossier - Record
            builder.HasOne(record => record.Project)
                   .WithOne(project => project.Record)
                   .HasForeignKey<Project>(project => project.RecordId);
            
            // Dossier - Advisor
            builder.HasOne(record => record.Reviewer)
                   .WithMany(advisor => advisor.ReviewerRecords)
                   .HasForeignKey(record => record.ReviewerId);
            
            builder.HasOne(record => record.InternalAdvisor)
                   .WithMany(advisor => advisor.InternalAdvisorRecords)
                   .HasForeignKey(record => record.InternalAdvisorId);
            
            builder.HasOne(record => record.ExternalAdvisor)
                   .WithMany(advisor => advisor.ExternalAdvisorRecords)
                   .HasForeignKey(record => record.ExternalAdvisorId);
        }
    }


}

