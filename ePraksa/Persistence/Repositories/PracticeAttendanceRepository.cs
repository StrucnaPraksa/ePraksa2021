using PracticeManagement.Core.Models;
using PracticeManagement.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace PracticeManagement.Persistence.Repositories
{
    public class PracticeAttendanceRepository : IPracticeAttendanceRepository
    {
        private readonly ApplicationDbContext _context;

        public PracticeAttendanceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddPracticeAttendance(PracticeAttendance practiceAttendance)
        {
            _context.PracticeAttendances.Add(practiceAttendance);
        }

        public void DeletePracticeAttendance(PracticeAttendance practiceAttendance)
        {
            _context.PracticeAttendances.Remove(practiceAttendance);
        }

        public void DeletePracticeAttendance(int id)
        {
            var entity = _context.PracticeAttendances.Find(id);
            _context.PracticeAttendances.Remove(entity);
        }

        public PracticeAttendance GetPracticeAttendance(int id)
        {
            return _context.PracticeAttendances.Find(id);
        }

        public IEnumerable<PracticeAttendance> GetPracticeAttendances(string userId, bool isStudent)
        {
            if (!isStudent)
                return _context.PracticeAttendances.ToList();

            var studentId = GetStudentId(userId);
            var practiceAttendances = _context.PracticeAttendances.Where(x => x.StudentId == studentId).ToList();

            return practiceAttendances;
        }

        public int GetStudentId(string userId)
        {
            var userEmail = _context.Users.First(x => x.Id == userId).Email;
            var studentId = _context.Students.First(x => x.Email == userEmail).Id;

            return studentId;
        }

        public void UpdatePracticeAttendance(PracticeAttendance practiceAttendance)
        {
            var exists = _context.PracticeAttendances.Any(x => x.Id == practiceAttendance.Id);
            if (!exists)
            {
                AddPracticeAttendance(practiceAttendance);
                return;
            }

            var entity = _context.PracticeAttendances.Find(practiceAttendance.Id);

            entity.Date = practiceAttendance.Date;
            entity.StudentId = practiceAttendance.StudentId;
            entity.TimeStart = practiceAttendance.TimeStart;
            entity.TimeEnd = practiceAttendance.TimeEnd;
            entity.MentorConfirmation = practiceAttendance.MentorConfirmation;
        }
    }
}
