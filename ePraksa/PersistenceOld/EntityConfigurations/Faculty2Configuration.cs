using System.Data.Entity.ModelConfiguration;
using PracticeManagement.Core.Models;

namespace PracticeManagement.Persistence.EntityConfigurations
{
    public class Faculty2Configuration : EntityTypeConfiguration<Faculty2>
    {
        public Faculty2Configuration()
        {
            Property(p => p.Name).IsRequired().HasMaxLength(255);
        }
    }
}