using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using PracticeManagement.Core.Models;
using PracticeManagement.Core.Repositories;

namespace PracticeManagement.Persistence.Repositories
{
    public class StudentPraksaRepository : IStudentPraksaRepository
    {
        private readonly ApplicationDbContext _context;
        public StudentPraksaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<StudentPraksa> GetStudentPraksas()
        {
            return _context.StudentPraksas
                .Include(f => f.Faculty)
                .Include(f => f.Firm)
                .Include(f => f.Mentor)
                .Include(f => f.Profesor)
                .Include(f => f.Student);
        }
    }
}