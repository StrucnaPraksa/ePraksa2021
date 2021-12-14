using System.Data.Entity.ModelConfiguration;
using PracticeManagement.Core.Models;

namespace PracticeManagement.Persistence.EntityConfigurations
{
    public class ProfesorConfiguration : EntityTypeConfiguration<Profesor>
    {
        public ProfesorConfiguration()
        {
            Property(d => d.PhysicianId).IsRequired();
            Property(d => d.SpecializationId).IsRequired();
            Property(d => d.Name).IsRequired().HasMaxLength(255);
            Property(d => d.Phone).IsRequired();
        }
    }
}