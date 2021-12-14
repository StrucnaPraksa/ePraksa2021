using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PracticeManagement.Core.Models;
using PracticeManagement.Core.Repositories;

namespace PracticeManagement.Persistence.Repositories
{
    public class MentorRepository : IMentorRepository
    {
        private readonly ApplicationDbContext _context;
        public MentorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get single Mentor - Admin
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Mentor GetMentor(int id)
        {
            return _context.Mentors
                .Include(f => f.Firm)
                .SingleOrDefault(d => d.Id == id);
        }

        public IEnumerable<Mentor> GetMentors()
        {
            return _context.Mentors
                .Include(f => f.Firm)
                .ToList();
        }

        public void Add(Mentor mentor)
        {
            _context.Mentors.Add(mentor);
        }

        public void Remove(Mentor mentor)
        {
            _context.Mentors.Remove(mentor);
        }
    }
}
