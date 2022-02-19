using PracticeManagement.Core.Models;
using System.Collections.Generic;

namespace PracticeManagement.Core.Repositories
{
    public interface IPracticeBreakRepository
    {
        IEnumerable<PracticeBreak> GetPracticeBreaks(int practiceAttendanceId);

        PracticeBreak GetPracticeBreak(int id);

        void AddPracticeBreak(PracticeBreak practiceBreak);

        void UpdatePracticeBreak(PracticeBreak practiceBreak);

        void DeletePracticeBreak(int id);

        void DeletePracticeBreak(PracticeBreak practiceBreak);
    }
}
