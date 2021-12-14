using PracticeManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace PracticeManagement.Persistence.EntityConfigurations
{
    public class FirmConfiguration : EntityTypeConfiguration<Firm>
    {
        public FirmConfiguration() {
            Property(p => p.Id).IsRequired();
            Property(p => p.Address).IsRequired();
            Property(p => p.Description).IsRequired();
            Property(p => p.TypeID).IsRequired();
            Property(p => p.Name).IsRequired();
        }
    }
}