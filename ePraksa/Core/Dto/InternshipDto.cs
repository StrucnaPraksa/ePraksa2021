using System.Collections.Generic;
using PracticeManagement.Core.Models;

namespace PracticeManagement.Core.Dto
{
    public class InternshipDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Plan { get; set; }
        public string Criteria { get; set; }
        public string Type { get; set; }
        public string Size { get; set; }
        public int ProfessorID { get; set; }
        //public Profesor Profesors { get; set; }
        public int YearID { get; set; }
        //public YearOfStudy YearOfStudies { get; set; }
        public int CourseID { get; set; }
        //public FacultyCourse FacultyCourses { get; set; }
        public int Status { get; set; }
    }
}