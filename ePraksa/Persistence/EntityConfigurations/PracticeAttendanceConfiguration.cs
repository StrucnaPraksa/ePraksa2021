using PracticeManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeManagement.Persistence.EntityConfigurations
{
    public class PracticeAttendanceConfiguration : EntityTypeConfiguration<PracticeAttendance>
    {
        public PracticeAttendanceConfiguration()
        {
            Property(p => p.Date).IsRequired();
            Property(p => p.StudentId).IsRequired();
            Property(p => p.TimeStart).IsRequired();
        }
    }
}
