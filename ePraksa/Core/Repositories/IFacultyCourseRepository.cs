using System.Collections.Generic;
using PracticeManagement.Core.Models;

namespace PracticeManagement.Core.Repositories
{
    public interface IFacultyCourseRepository
    {
        FacultyCourse GetFacultyCourse(int id);
        IEnumerable<FacultyCourse> GetFacultyCourses();
    }
}
