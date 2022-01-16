using System;
using System.ComponentModel.DataAnnotations;

namespace PracticeManagement.Core.Models
{
    public class PracticeAttendance
    {
        public int Id { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
        public DateTime Date { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public bool MentorConfirmation { get; set; }
    }
}
