using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using PracticeManagement.Core.Models;
using PracticeManagement.Core.Repositories;

namespace PracticeManagement.Persistence.Repositories
{
    public class StudentDnevnikRepository : IStudentDnevnikRepository
    {
        private readonly ApplicationDbContext _context;
        public StudentDnevnikRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<StudentDnevnik> GetStudentDnevniks()
        {
            return _context.StudentDnevniks
                .Include(f => f.StudentPraksa)
                .Include(f => f.StudentPraksa.Mentor)
                .Include(f => f.StudentPraksa.Firm);
        }

        public StudentDnevnik GetStudentDnevnik(int id)
        {
            return _context.StudentDnevniks
                .Include(f => f.StudentPraksa)
                .Include(f => f.StudentPraksa.Mentor)
                .Include(f => f.StudentPraksa.Firm)
                .SingleOrDefault(f => f.Id == id);
        }

        public void Add(StudentDnevnik studentDnevnik)
        {
            _context.StudentDnevniks.Add(studentDnevnik);
        }

        public void Delete(int id)
        {
            StudentDnevnik studentDnevnik = _context.StudentDnevniks.Find(id);
            _context.StudentDnevniks.Remove(studentDnevnik);
        }
    }
}