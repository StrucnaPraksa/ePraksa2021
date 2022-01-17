using System.Collections.Generic;
using PracticeManagement.Core.Models;

namespace PracticeManagement.Core.Repositories
{
   
    public interface IStudentRateRepository
    {
        IEnumerable<StudentRate> GetStudentRates();
        
        StudentRate GetStudentRate(int id);
        
        void Add(StudentRate studentRate);
        
        void Remove(StudentRate studentRate);
    }
}
