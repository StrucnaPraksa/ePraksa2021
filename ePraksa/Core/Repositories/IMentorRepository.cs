using System.Collections.Generic;
using PracticeManagement.Core.Models;

namespace PracticeManagement.Core.Repositories
{
    public interface IMentorRepository
    {
        IEnumerable<Mentor> GetMentors();
        Mentor GetMentor(int id);
        void Add(Mentor mentor);
        void Remove(Mentor mentor);
    }
}
