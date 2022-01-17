using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PracticeManagement.Core.Models
{
    public class PollMentorAnswer
    {
        [Key]
        public int Id { get; set; }
        public int MentorsID { get; set; }
        public Mentor Mentors { get; set; }
        public int A1 { get; set; }
        public int A2 { get; set; }
        public int A3 { get; set; }
        public int A4 { get; set; }
        public int A5 { get; set; }
        public int FinalGrade { get; set; }
        public int StudentsID { get; set; }
        public bool Active { get; set; }
        public Student Students { get; set; }
    }
}