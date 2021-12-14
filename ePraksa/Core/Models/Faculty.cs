using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
namespace PracticeManagement.Core.Models
{
    public class Faculty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FacultyAddress { get; set; }

        public int FacultyTypeID { get; set; }
        public FacultyType FacultyTypes { get; set; }
        public int FacultySectorId { get; set; }
        public FacultySector FacultySectors { get; set; }
        public string Programi { get; set; }
        public string Description { get; set; }
        public bool Activity { get; set; }

        //public ICollection<FacultyType> FacultyTypes { get; set; }
        //public ICollection<FacultySector> FacultySectors { get; set; }


    }
}