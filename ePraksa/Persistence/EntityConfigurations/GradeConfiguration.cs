using System.Data.Entity.ModelConfiguration;
using PracticeManagement.Core.Models;


namespace PracticeManagement.Persistence.EntityConfigurations
{
    public class GradeConfiguration : EntityTypeConfiguration<Grade>
    {
        public GradeConfiguration()
        {
            Property(d => d.Id).IsRequired();

        }
    }
}