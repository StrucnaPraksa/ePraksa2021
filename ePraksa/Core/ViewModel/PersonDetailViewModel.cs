using System.Collections.Generic;
using PracticeManagement.Core.Models;

namespace PracticeManagement.Core.ViewModel
{
    public class PersonDetailViewModel
    {
        public Person Person { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }
        public int CountAppointments { get; set; }
        public int CountAttendance { get; set; }
    }
}