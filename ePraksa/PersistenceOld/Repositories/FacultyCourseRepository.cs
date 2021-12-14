using PracticeManagement.Core.Models;
using PracticeManagement.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace PracticeManagement.Persistence.Repositories
{
    public class FacultyCourseRepository : IFacultyCourseRepository
    {
        private readonly ApplicationDbContext _context;

        public FacultyCourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public FacultyCourse GetFacultyCourse(int id)
        {
            return _context.FacultyCourses
                .SingleOrDefault(d => d.Id == id);
        }
        public IEnumerable<FacultyCourse> GetFacultyCourses()
        {
            return _context.FacultyCourses.ToList();
        }
    }
}
