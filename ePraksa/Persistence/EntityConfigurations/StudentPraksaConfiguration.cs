using PracticeManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace PracticeManagement.Persistence.EntityConfigurations
{
    public class StudentPraksaConfiguration: EntityTypeConfiguration<StudentPraksa>
    {
        public StudentPraksaConfiguration()
        {
            Property(p => p.Id).IsRequired();
            Property(p => p.fakultetId).IsRequired();
            Property(p => p.firmaId).IsRequired();
            Property(p => p.mentorId).IsRequired();
            Property(p => p.profesorId).IsRequired();
            Property(p => p.studentId).IsRequired();
        }
    }
}