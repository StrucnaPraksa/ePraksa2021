using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using PracticeManagement.Core.Models;
using PracticeManagement.Core.Repositories;

namespace PracticeManagement.Persistence.Repositories
{
    public class GradeRepository : IGradeRepository
    {
        private readonly ApplicationDbContext _context;

        public GradeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Grade> GetGrades()
        {
            return _context.Grades
              .Include(b => b.Profesors)
              .Include(c => c.Mentors)
              .Include(e => e.Firms)
              .Include(f => f.Students)
              .Include(i => i.Internships)
              .ToList();
        }

        public Grade GetGrade(int id)
        {
            return _context.Grades
                .SingleOrDefault(d => d.Id == id);
        }

        public void Add(Grade grade)
        {
            _context.Grades.Add(grade);
        }

        public IEnumerable<Grade> GetGrades(int id)
        {
            return _context.Grades.ToList();
        }

        public void Remove(Grade grade)
        {
            _context.Grades.Remove(grade);
        }

    }
}