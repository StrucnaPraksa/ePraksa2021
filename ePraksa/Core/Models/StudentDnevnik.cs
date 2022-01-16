using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PracticeManagement.Core.Models
{
    public class StudentDnevnik
    {
        public int Id { get; set; }

        [ForeignKey("StudentPraksa")]
        public int studentPraksaId { get; set; }
        public bool Odobreno { get; set; }
        public DateTime datum { get; set; }
        public string aktivnost { get; set; }
        public string linkovi { get; set; }
        public string dodatno { get; set; }
        public string komentar { get; set; }
        public StudentPraksa StudentPraksa { get; set; }
    }
}