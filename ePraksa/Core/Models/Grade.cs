using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;


namespace PracticeManagement.Core.Models
{
    public class Grade
    {
        public int Id { get; set; }
        [ForeignKey("Internships")]
        public int PracticeId { get; set; }
        public Internship Internships { get; set; }
        [ForeignKey("Mentors")]
        public int MentorId { get; set; }
        public Mentor Mentors { get; set; }
        [ForeignKey("Profesors")]
        public int ProfesorId { get; set; }
        public Profesor Profesors { get; set; }
        [ForeignKey("Students")]
        public int StudentId { get; set; }
        public Student Students { get; set; }
        [ForeignKey("Firms")]
        public int FirmId { get; set; }
        public Firm Firms { get; set; }
        public int PGrade1 { get; set; }
        public int PGrade2 { get; set; }
        public int PGrade3 { get; set; }
        public int MGrade1 { get; set; }
        public int MGrade2 { get; set; }
        public int MGrade3 { get; set; }
        public string ProfesorComment { get; set; }
        public string MentorComment { get; set; }
   

    }
}