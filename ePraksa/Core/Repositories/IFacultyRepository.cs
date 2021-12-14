using System.Collections.Generic;
using PracticeManagement.Core.Models;

namespace PracticeManagement.Core.Repositories
{
    public interface IFacultyRepository
    {
        IEnumerable<Faculty> GetFaculties();
       // IEnumerable<Faculty> GetFaculty();

        Faculty GetFaculty(int id);
        //Profesor GetProfile(string userId);
        //void Add(Faculty Faculty);
    }
}