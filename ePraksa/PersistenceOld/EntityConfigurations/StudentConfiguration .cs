using System.Data.Entity.ModelConfiguration;
using PracticeManagement.Core.Models;

namespace PracticeManagement.Persistence.EntityConfigurations
{
    public class StudentConfiguration : EntityTypeConfiguration<Student>
    {
        public StudentConfiguration()
        {
            Property(d => d.Id).IsRequired();
            Property(d => d.Firstname).IsRequired().HasMaxLength(50);
            Property(d => d.Lastname).IsRequired().HasMaxLength(50);
            Property(d => d.Email).IsRequired().HasMaxLength(50);
            Property(d => d.CityId).IsRequired();
            Property(d => d.FacultyId).IsRequired();
            Property(d => d.FacultyCourseId).IsRequired();
            Property(d => d.CV).IsRequired().HasMaxLength(50);
            Property(d => d.Active).IsRequired();
        }
    }
}
