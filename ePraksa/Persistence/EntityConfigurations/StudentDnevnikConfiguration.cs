using PracticeManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace PracticeManagement.Persistence.EntityConfigurations
{
    public class StudentDnevnikConfiguration: EntityTypeConfiguration<StudentDnevnik>
    {
        public StudentDnevnikConfiguration()
        {
            Property(p => p.Id).IsRequired();
            Property(p => p.studentPraksaId).IsRequired();
            Property(p => p.datum).IsRequired();
            Property(p => p.aktivnost).IsRequired();
            Property(p => p.linkovi).IsRequired();
        }
    }
}