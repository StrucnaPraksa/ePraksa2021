using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace PracticeManagement.Core.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public byte CityID { get; set; }
        public City City { get; set; }
        public int FacultyID { get; set; }
        public Faculty Faculty { get; set; }
        public int FacultyCourseId { get; set; }
        public FacultyCourse FacultyCourses { get; set; }
        public int YearOfStudyID { get; set; }
        public YearOfStudy YearOfStudies { get; set; }
        public string CV { get; set; }
        public int Active { get; set; }

        //public ICollection<FacultyType> FacultyTypes { get; set; }
        //public ICollection<FacultySector> FacultySectors { get; set; }


    }
}