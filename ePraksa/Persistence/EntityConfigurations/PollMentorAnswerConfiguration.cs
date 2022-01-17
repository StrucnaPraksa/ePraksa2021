using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
//using System.Data.Entity.ModelConfiguration;
using PracticeManagement.Core.Models;


namespace PracticeManagement.Persistence.EntityConfigurations
{
    public class PollMentorAnswerConfiguration : EntityTypeConfiguration<PollMentorAnswer>
    {
        public PollMentorAnswerConfiguration()
        {
            Property(p => p.A1).IsRequired();
        }

    }
}