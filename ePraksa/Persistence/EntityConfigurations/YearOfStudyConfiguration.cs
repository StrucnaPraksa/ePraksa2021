using System.Data.Entity.ModelConfiguration;
using PracticeManagement.Core.Models;

namespace PracticeManagement.Persistence.EntityConfigurations
{
    public class YearOfStudyConfiguration : EntityTypeConfiguration<YearOfStudy>
    {
        public YearOfStudyConfiguration()
        {
            Property(p => p.Year).IsRequired();
        }
    }
}