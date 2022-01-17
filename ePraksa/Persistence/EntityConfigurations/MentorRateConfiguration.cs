using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
//using System.Data.Entity.ModelConfiguration;
using PracticeManagement.Core.Models;


namespace PracticeManagement.Persistence.EntityConfigurations
{
    public class MentorRateConfiguration : EntityTypeConfiguration<MentorRate>
    {
        public MentorRateConfiguration()
        {
            //Property(p => p.FirstName).IsRequired().HasMaxLength(255);
        }

    }
}