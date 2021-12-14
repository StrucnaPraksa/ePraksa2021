using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace PracticeManagement.Core.Models
{
    // [Table("Faculties")]
    //System.ComponentModel.DataAnnotations.Schema;
    //[System.ComponentModel.DataAnnotations.Schema.Table("Faculties")];
    public class Faculty2
    {
  
        [Key]
        public int FacultyID { get; set; }
        public string Name { get; set; }
        public string FacultyAddress { get; set; }

        public int FacultyTypeID { get; set; }
        public FacultyType FacultyType { get; set; }
        public int FacultySectorId { get; set; }
        public FacultySector FacultySector { get; set; }
        public string Programi { get; set; }
        public string Description { get; set; }
        public bool Activity { get; set; }

        //public ICollection<FacultyType> FacultyTypes { get; set; }
        //public ICollection<FacultySector> FacultySectors { get; set; }


    }
}