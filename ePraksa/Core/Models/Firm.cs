using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PracticeManagement.Core.Models
{
    public class Firm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Activated { get; set; }
        [ForeignKey("FirmType")]
        public int TypeID { get; set; }
        public virtual FirmType FirmType { get; set; }
        [ForeignKey("FirmAddress")]
        public int Address { get; set; }
        public virtual FirmAddress FirmAddress { get; set; }
    }
}