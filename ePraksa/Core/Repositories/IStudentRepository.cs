using System.Collections.Generic;
using PracticeManagement.Core.Models;

namespace PracticeManagement.Core.Repositories
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetStudents();
        void Remove(Student student);
        void Add(Student student);
        Student GetStudent(int id);
    }
}