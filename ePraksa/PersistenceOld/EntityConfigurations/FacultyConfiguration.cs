using System.Data.Entity.ModelConfiguration;
using PracticeManagement.Core.Models;

namespace PracticeManagement.Persistence.EntityConfigurations
{
    public class FacultyConfiguration : EntityTypeConfiguration<Faculty>
    {
        public FacultyConfiguration()
        {
            Property(p => p.Name).IsRequired().HasMaxLength(255);
        }
    }
}