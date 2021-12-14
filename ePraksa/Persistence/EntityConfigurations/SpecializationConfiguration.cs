using System.Data.Entity.ModelConfiguration;
using PracticeManagement.Core.Models;

namespace PracticeManagement.Persistence.EntityConfigurations
{
    public class SpecializationConfiguration : EntityTypeConfiguration<Specialization>
    {
        public SpecializationConfiguration()
        {
            Property(s => s.Name).IsRequired().HasMaxLength(255);
        }
    }
}