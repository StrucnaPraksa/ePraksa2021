using PracticeManagement.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace PracticeManagement.Persistence.EntityConfigurations
{
    public class FacultyCourseConfiguration : EntityTypeConfiguration<FacultyCourse>
    {
        public FacultyCourseConfiguration()
        {
            Property(p => p.Id).IsRequired();
            Property(p => p.Course).IsRequired().HasMaxLength(50);
        }
    }
}
