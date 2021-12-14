using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace PracticeManagement.Core.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //public int SpecializationId { get; set; }
        //public Specialization Specialization { get; set; }

        public int FacultyId { get; set; }

        public Faculty Faculty { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        //public ICollection<Faculty> Faculties { get; set; }

        //public Person()
        //{
        //    Faculties = new Collection<Faculty>();
        //}
    }
}