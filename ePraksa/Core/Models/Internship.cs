using System.ComponentModel.DataAnnotations.Schema;

namespace PracticeManagement.Core.Models
{
    /// <summary>
    /// author: Grgo Jelavic
    /// date: 20.12.2021.
    /// </summary>
    public class Internship
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Plan { get; set; }
        public string Criteria { get; set; }
        public string Type { get; set; }
        public string Size { get; set; }
        [ForeignKey("Profesors")]
        public int ProfessorID { get; set; }
        public Profesor Profesors { get; set; }
        [ForeignKey("YearOfStudies")]
        public int YearID { get; set; }
        public YearOfStudy YearOfStudies { get; set; }
        [ForeignKey("FacultyCourses")]
        public int CourseID { get; set; }
        public FacultyCourse FacultyCourses { get; set; }
        public int Status { get; set; }
    }
}