using System.Collections.Generic;
using PracticeManagement.Core.Models;

namespace PracticeManagement.Core.ViewModel
{
    public class GradeDetailViewModel
    {

        public Grade Grade { get; set; }
        public int PGrade1 { get; set; }
        public int PGrade2 { get; set; }
        public int PGrade3 { get; set; }
        public int MGrade1 { get; set; }
        public int MGrade2 { get; set; }
        public int MGrade3 { get; set; }
        public string ProfesorComment { get; set; }
        public string MentorComment { get; set; }
    }
}