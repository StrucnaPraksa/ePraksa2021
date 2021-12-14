using PracticeManagement.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace PracticeManagement.Persistence.EntityConfigurations
{
    public class AttendanceConfiguration : EntityTypeConfiguration<Attendance>
    {
        public AttendanceConfiguration()
        {
            Property(p => p.PatientId).IsRequired();
            Property(p => p.PracticeRemarks).IsRequired();
            Property(p => p.Diagnosis).IsRequired().HasMaxLength(255);
            Property(p => p.Therapy).IsRequired();
        }
    }
}