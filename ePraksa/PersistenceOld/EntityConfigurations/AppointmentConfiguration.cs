using PracticeManagement.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace PracticeManagement.Persistence.EntityConfigurations
{
    public class AppointmentConfiguration : EntityTypeConfiguration<Appointment>
    {
        public AppointmentConfiguration()
        {
            Property(a => a.PatientId).IsRequired();
            Property(a => a.ProfesorId).IsRequired();
            Property(a => a.StartDateTime).IsRequired();
            Property(a => a.Detail).IsRequired();
            Property(a => a.Status).IsRequired();
        }
    }
}