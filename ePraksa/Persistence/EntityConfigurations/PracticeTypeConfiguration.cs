using PracticeManagement.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace PracticeManagement.Persistence.EntityConfigurations
{
    public class PracticeTypeConfiguration : EntityTypeConfiguration<PracticeType>
    {
        public PracticeTypeConfiguration()
        {
            Property(p => p.Id).IsRequired();
            Property(p => p.Description).IsRequired().HasMaxLength(50);
            Property(p => p.Hours).IsRequired();
        }
    }
}