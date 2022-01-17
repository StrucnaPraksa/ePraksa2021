using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PracticeManagement.Core.Models;
using PracticeManagement.Core.Repositories;

namespace PracticeManagement.Persistence.Repositories
{
    public class MentorRateRepository : IMentorRateRepository
    {
        private readonly ApplicationDbContext _context;

        public MentorRateRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<MentorRate> GetMentorRates()
        {
            return _context.MentorRates
                .Include(m => m.Mentors)
                .Include(m => m.Students)
                .Include(m => m.Internships)
                .ToList();
        }
        public MentorRate GetMentorRate(int id)
        {
            return _context.MentorRates
                //.Include(f => f.Firm)
                .SingleOrDefault(d => d.Id == id);
        }

        public void Add(MentorRate mentorRate)
        {
            _context.MentorRates.Add(mentorRate);
        }
        public void Remove(MentorRate mentorRate)
        {
            _context.MentorRates.Remove(mentorRate);
        }

    }
}