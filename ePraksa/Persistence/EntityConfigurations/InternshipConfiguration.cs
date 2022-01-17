using System.Data.Entity.ModelConfiguration;
using PracticeManagement.Core.Models;

namespace PracticeManagement.Persistence.EntityConfigurations
{
    /// <summary>
    /// author: Grgo Jelavic
    /// description: define required properties for internship configuration
    /// date: 20.12.2021.
    /// </summary>
    public class InternshipConfiguration : EntityTypeConfiguration<Internship>
    {
        public InternshipConfiguration()
        {
            Property(d => d.Id).IsRequired();

            Property(d => d.Name).IsRequired().HasMaxLength(50);

            Property(d => d.ProfessorID).IsRequired();

            Property(d => d.CourseID).IsRequired();

            Property(d => d.YearID).IsRequired();
        }
    }
}