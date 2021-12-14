using PracticeManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace PracticeManagement.Persistence.EntityConfigurations
{
    public class FirmTypeConfiguration : EntityTypeConfiguration<FirmType>
    {
        public FirmTypeConfiguration()
        {
            Property(p => p.Id).IsRequired();
            Property(p => p.Type).IsRequired();
        }
    }
}