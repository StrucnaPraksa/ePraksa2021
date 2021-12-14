namespace PracticeManagement.Core.Dto
{
    public class Faculty2Dto
    {
        public int FacultyID { get; set; }
        public string Name { get; set; }
        public string FacultyAddress { get; set; }


        public int FacultyTypeID { get; set; }
       // public FacultyType FacultyType { get; set; }
        public int FacultySectorID { get; set; }
        public FacultySectorDto FacultySector { get; set; }
        public string Programi { get; set; }
        public string Description { get; set; }
        public bool Activity { get; set; }
    }
}