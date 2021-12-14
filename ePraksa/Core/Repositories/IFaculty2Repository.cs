using System.Collections.Generic;
using PracticeManagement.Core.Models;

namespace PracticeManagement.Core.Repositories
{
    public interface IFaculty2Repository
    {
        IEnumerable<Faculty2> GetFaculties2();
       // IEnumerable<Faculty2> GetFaculty2();

        // Person GetFaculty(int id);
        //Profesor GetProfile(string userId);
        //void Add(Faculty Faculty);
    }
}