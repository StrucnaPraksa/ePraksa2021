using PracticeManagement.Core.Models;
using PracticeManagement.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace PracticeManagement.Persistence.Repositories
{
    public class PracticeBreakRepository : IPracticeBreakRepository
    {
        private readonly ApplicationDbContext _context;

        public PracticeBreakRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddPracticeBreak(PracticeBreak practiceBreak)
        {
            _context.PracticeBreaks.Add(practiceBreak);
        }

        public void DeletePracticeBreak(int id)
        {
            var entity = _context.PracticeBreaks.Find(id);
            _context.PracticeBreaks.Remove(entity);
        }

        public void DeletePracticeBreak(PracticeBreak practiceBreak)
        {
            _context.PracticeBreaks.Remove(practiceBreak);
        }

        public PracticeBreak GetPracticeBreak(int id)
        {
            return _context.PracticeBreaks.Include(x => x.PracticeAttendance).First(x => x.Id == id);
        }

        public IEnumerable<PracticeBreak> GetPracticeBreaks()
        {
            return _context.PracticeBreaks.Include(x => x.PracticeAttendance).ToList();
        }

        public void UpdatePracticeBreak(PracticeBreak practiceBreak)
        {
            var exists = _context.PracticeBreaks.Any(x => x.Id == practiceBreak.Id);
            if (!exists)
            {
                AddPracticeBreak(practiceBreak);
                return;
            }

            var entity = _context.PracticeBreaks.Find(practiceBreak.Id);

            entity.PracticeAttendanceId = practiceBreak.PracticeAttendanceId;
            entity.TimeStart = practiceBreak.TimeStart;
            entity.TimeEnd = practiceBreak.TimeEnd;
        }
    }
}
