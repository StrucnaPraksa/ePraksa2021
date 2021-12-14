using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticeManagement.Core.Models
{
    public class FirmAddress
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int PostalNumber { get; set; }
    }
}