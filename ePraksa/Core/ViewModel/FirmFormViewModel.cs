using PracticeManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PracticeManagement.Core.ViewModel
{
    public class FirmFormViewModel
    {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Deacription { get; set; }

        [Required]
        public int Address { get; set; }
        public IEnumerable<FirmAddress> FirmAddreses { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public int PostalNumber { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public bool Activated { get; set; }

        [Required]
        public int TypeID { get; set; }
        public IEnumerable<FirmType> FirmTypes { get; set; }

        public string Heading { get; set; }
    }
}