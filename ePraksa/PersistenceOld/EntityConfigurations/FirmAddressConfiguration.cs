using PracticeManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace PracticeManagement.Persistence.EntityConfigurations
{
    public class FirmAddressConfiguration : EntityTypeConfiguration<FirmAddress>
    {
        public FirmAddressConfiguration()
        {
            Property(p => p.Id).IsRequired();
            Property(p => p.City).IsRequired();
            Property(p => p.Street).IsRequired();
            Property(p => p.PostalNumber).IsRequired();
        }
    }
}