using System.Data.Entity.ModelConfiguration;
using PracticeManagement.Core.Models;

namespace PracticeManagement.Persistence.EntityConfigurations
{
    public class MentorConfiguration : EntityTypeConfiguration<Mentor>
    {
        public MentorConfiguration()
        {
            Property(d => d.Id).IsRequired();
            Property(d => d.FirstName).IsRequired().HasMaxLength(50);
            Property(d => d.LastName).IsRequired().HasMaxLength(50);
            Property(d => d.Title).IsRequired().HasMaxLength(50);
            Property(d => d.Occupation).IsRequired().HasMaxLength(50);
            Property(d => d.Email).IsRequired().HasMaxLength(50);
            Property(d => d.Address).IsRequired().HasMaxLength(50);
            Property(d => d.FirmId).IsRequired();
            Property(d => d.YearsOfExperience).IsRequired();
            Property(d => d.Competence).IsRequired().HasMaxLength(50);
            Property(d => d.CV).IsRequired().HasMaxLength(50);

        }
    }
}
