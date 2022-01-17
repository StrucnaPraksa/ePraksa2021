using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PracticeManagement.Core.Models;
using PracticeManagement.Core.Repositories;

namespace PracticeManagement.Persistence.Repositories
{
    public class PollMentorAnswerRepository : IPollMentorAnswerRepository
    {
        private readonly ApplicationDbContext _context;

        public PollMentorAnswerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<PollMentorAnswer> GetPollMentorAnswers()
        {
            return _context.PollMentorAnswers
                .Include(m => m.Mentors)
                .Include(s => s.Students)
                .ToList();
        }
        public PollMentorAnswer GetPollMentorAnswer(int id)
        {
            return _context.PollMentorAnswers
                .Include(m => m.Mentors)
                .Include(s => s.Students)
                .SingleOrDefault(d => d.Id == id);
        }

        public void Add(PollMentorAnswer pollMentorAnswer)
        {
            _context.PollMentorAnswers.Add(pollMentorAnswer);
        }
        public void Remove(PollMentorAnswer pollMentorAnswer)
        {
            _context.PollMentorAnswers.Remove(pollMentorAnswer);
        }

    }
}