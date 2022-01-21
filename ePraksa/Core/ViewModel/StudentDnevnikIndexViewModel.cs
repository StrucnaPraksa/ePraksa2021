using PracticeManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticeManagement.Core.ViewModel
{
    public class StudentDnevnikIndexViewModel
    {
        public IEnumerable<StudentDnevnik> StudentDnevniks { get; set; }
        public int praksaId { get; set; }

    }
}