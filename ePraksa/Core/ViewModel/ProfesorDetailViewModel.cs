using System.Collections.Generic;
using PracticeManagement.Core.Models;

namespace PracticeManagement.Core.ViewModel
{
    public class ProfesorDetailViewModel
    {
        public Profesor Profesor { get; set; }
        public IEnumerable<Appointment> UpcomingAppointments { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }
    }
}