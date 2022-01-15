using PracticeManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace PracticeManagement.Persistence.EntityConfigurations
{
    public class PracticeBreakConfiguration: EntityTypeConfiguration<PracticeBreak>
    {
        public PracticeBreakConfiguration()
        {
            Property(p => p.PracticeAttendanceId).IsRequired();
            Property(p => p.TimeStart).IsRequired();
        }
    }
}