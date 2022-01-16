using System.ComponentModel.DataAnnotations.Schema;

namespace PracticeManagement.Core.Models
{
    public class StudentPraksa
    {
        public int Id { get; set; }

        [ForeignKey("Faculty")]
        public int fakultetId { get; set; }

        [ForeignKey("Firm")]
        public int firmaId { get; set; }

        [ForeignKey("Mentor")]
        public int mentorId { get; set; }

        [ForeignKey("Profesor")]
        public int profesorId { get; set; }

        [ForeignKey("Student")]
        public int studentId { get; set; }

        public Faculty Faculty { get; set; }
        public Firm Firm { get; set; }
        public Mentor Mentor { get; set; }
        public Profesor Profesor { get; set; }
        public Student Student { get; set; }

    }
}