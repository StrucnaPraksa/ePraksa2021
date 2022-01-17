using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PracticeManagement.Core.Models
{
    public class StudentRate
    {
        [Key]
        public int Id { get; set; }
        //public int PollMentorAnswersID { get; set; }
       // public PollMentorAnswer PollMentorAnswers { get; set; }
       [ForeignKey("Mentors")]
        public int MentorsID { get; set; }
        public Mentor Mentors { get; set; }
        [ForeignKey("Students")]
        public int StudentsID { get; set; }
        public Student Students { get; set; }

        // public string Firstname { get; set; }
        // public string Lastname { get; set; }
        //public string Email { get; set; }
        //public int CityID { get; set; }

        [ForeignKey("Internships")]
        public int InternshipsID { get; set; }

        public Internship Internships { get; set; }
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
         /* public byte CityID { get; set; }
          public City City { get; set; }

          public int FacultyID { get; set; }
          public Faculty Faculties { get; set; }
         public int FacultyCourseId { get; set; }
          public FacultyCourse FacultyCourses { get; set; }

          public int YearOfStudyID { get; set; }
          public YearOfStudy YearOfStudies { get; set; }*/
         // public string CV { get; set; } 
        [Required]
        public decimal Rate { get; set; }
        public bool Active { get; set; }

        //public ICollection<FacultyType> FacultyTypes { get; set; }
        //public ICollection<FacultySector> FacultySectors { get; set; }


    }
}