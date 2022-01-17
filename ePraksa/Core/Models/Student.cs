using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
namespace PracticeManagement.Core.Models

{
    public class Student
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }

        [ForeignKey("City")]
        public byte CityID { get; set; }
        public City City { get; set; }

        [ForeignKey("Faculty")]
        public int FacultyID { get; set; }
        public Faculty Faculty { get; set; }
       // [ForeignKey("FacultyCourse")]
        public int FacultyCourseId { get; set; }
        public FacultyCourse FacultyCourses { get; set; }
        //[ForeignKey("YearOfStudy")]
        public int YearOfStudyID { get; set; }
        public YearOfStudy YearOfStudies { get; set; }

        public string CV { get; set; }
        public int Active { get; set; }

        //public ICollection<FacultyType> FacultyTypes { get; set; }
        //public ICollection<FacultySector> FacultySectors { get; set; }


    }
}