using System.Data.Entity.ModelConfiguration;
using PracticeManagement.Core.Models;

namespace PracticeManagement.Persistence.EntityConfigurations
{
    public class PatientStatusConfiguration : EntityTypeConfiguration<PatientStatus>
    {
        public PatientStatusConfiguration()
        {
            Property(s => s.Name).IsRequired().HasMaxLength(255);
        }
    }
}