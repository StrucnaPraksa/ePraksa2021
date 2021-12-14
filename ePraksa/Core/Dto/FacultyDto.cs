namespace PracticeManagement.Core.Dto
{
    public class FacultyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FacultyAddress { get; set; }
        public int FacultyTypeID { get; set; }
        public FacultyTypeDto FacultyTypes { get; set; }
        public int FacultySectorID { get; set; }
        public FacultySectorDto FacultySectors { get; set; }
        public string Programi { get; set; }
        public string Description { get; set; }
        public bool Activity { get; set; }
    }
}