using System.Collections.Generic;
using PracticeManagement.Core.Models;

namespace PracticeManagement.Core.Repositories
{
    // damir-zrinka added key word public 
    public interface IMentorRateRepository
    {
        IEnumerable<MentorRate> GetMentorRates();

        MentorRate GetMentorRate(int id);
        // damir-zrinka commented MentorRate GetMentorRate(int id);
        void Add(MentorRate mentorRate);
        void Remove(MentorRate mentorRate);
    }
}
