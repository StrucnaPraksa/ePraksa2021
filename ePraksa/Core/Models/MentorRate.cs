using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PracticeManagement.Core.Models
{
    public class MentorRate
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Mentors")]
        public int MentorsID { get; set; }

        public Mentor Mentors { get; set; }
        //public string FirstName { get; set; }
        [Required]
        public int A1 { get; set; }
        [Required]
        public int A2 { get; set; }
        [Required]
        public int A3 { get; set; }
        [Required]
        public int A4 { get; set; }
        [Required]
        public int A5 { get; set; }

        [ForeignKey("Internships")]
        public int InternshipsID { get; set; }

        public Internship Internships { get; set; }
        [Required]
        public decimal Rate { get; set; }

        //public int PollStudentId { get; set; }
        //public PollStudent PollStudents { get; set; }
        [ForeignKey("Students")]
        public int StudentsID { get; set; }
        public Student Students { get; set; }

        public bool Activated { get; set; }
    }
}