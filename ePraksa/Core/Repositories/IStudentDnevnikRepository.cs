using PracticeManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticeManagement.Core.Repositories
{
    public interface IStudentDnevnikRepository
    {
        IEnumerable<StudentDnevnik> GetStudentDnevniks(int praksaId);
        void Add(StudentDnevnik studentDnevnik);
        void Delete(int id);
        StudentDnevnik GetStudentDnevnik(int id);
    }
}