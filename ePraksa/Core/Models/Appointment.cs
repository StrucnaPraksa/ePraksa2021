using System;

namespace PracticeManagement.Core.Models
{
    public class Appointment
    {

        public int Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public string Detail { get; set; }
        public bool Status { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int ProfesorId { get; set; }
        public Profesor Profesor { get; set; }
    }

}
