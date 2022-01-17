using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using PracticeManagement.Core.Models;

namespace PracticeManagement.Persistence.EntityConfigurations
{
    public class StudentRateConfiguration : EntityTypeConfiguration<StudentRate>
    {
        public StudentRateConfiguration()
        {
            //Property(d => d.Id).IsRequired();
            //Property(d => d.Students.Firstname).IsRequired().HasMaxLength(50);
            //Property(d => d.Students.Lastname).IsRequired().HasMaxLength(50);
            //Property(d => d.Email).IsRequired().HasMaxLength(50);
            //Property(d => d.CityId).IsRequired();
            //Property(d => d.FacultyId).IsRequired();
            //Property(d => d.FacultyCourseId).IsRequired();
           //Property(d => d.CV).IsRequired().HasMaxLength(50);
            //Property(d => d.Active).IsRequired();
        }
    }
}
