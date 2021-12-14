using System.Collections.Generic;
using PracticeManagement.Core.Models;

namespace PracticeManagement.Core.ViewModel
{
    public class FacultyDetailViewModel
    {
        public Faculty Faculty { get; set; }
        public IEnumerable<Appointment> UpcomingAppointments { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }
        public int CountAppointments { get; set; }
        public int CountAttendance { get; set; }
    }
}