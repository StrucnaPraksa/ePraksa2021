using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticeManagement.Core.Models
{
    public class PracticeType
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Hours { get; set; }
    }
}