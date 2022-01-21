using PracticeManagement.Core.Models;
using System.Collections.Generic;

namespace PracticeManagement.Core.Repositories
{
    public interface IPracticeAttendanceRepository
    {
        IEnumerable<PracticeAttendance> GetPracticeAttendances();

        PracticeAttendance GetPracticeAttendance(int id);

        void DeletePracticeAttendance(PracticeAttendance practiceAttendance);

        void DeletePracticeAttendance(int id);

        void UpdatePracticeAttendance(PracticeAttendance practiceAttendance);

        void AddPracticeAttendance(PracticeAttendance practiceAttendance);
    }
}
