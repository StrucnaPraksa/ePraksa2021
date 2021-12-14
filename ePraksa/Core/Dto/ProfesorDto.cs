using System.Collections.Generic;
using PracticeManagement.Core.Models;

namespace PracticeManagement.Core.Dto
{
    public class ProfesorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public bool IsAvailable { get; set; }
        public string Address { get; set; }
        public int SpecializationId { get; set; }
        public SpecializationDto Specialization { get; set; }
        public ICollection<Appointment> Appointments { get; set; }



    }
}