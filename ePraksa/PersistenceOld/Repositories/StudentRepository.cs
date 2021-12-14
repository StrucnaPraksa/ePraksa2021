using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PracticeManagement.Core.Models;
using PracticeManagement.Core.Repositories;

namespace PracticeManagement.Persistence.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;
        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get single Student - Admin
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Student GetStudent(int id)
        {
            return _context.Students
                .Include(f => f.Faculty)
                .Include(c => c.FacultyCourse)
                .SingleOrDefault(d => d.Id == id);
        }

        public IEnumerable<Student> GetStudents()
        {
            return _context.Students
                .Include(f => f.Faculty)
                .Include(c => c.FacultyCourse)
                .ToList();
        }
    }
}
