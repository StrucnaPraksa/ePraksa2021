using System.Collections.Generic;
using PracticeManagement.Core.Models;

namespace PracticeManagement.Core.Repositories
{
    // damir-zrinka added key word public 
    public interface IPollMentorAnswerRepository
    {
        IEnumerable<PollMentorAnswer> GetPollMentorAnswers();

        PollMentorAnswer GetPollMentorAnswer(int id);
        // damir-zrinka commented MentorRate GetMentorRate(int id);
        void Add(PollMentorAnswer pollMentorAnswer);
        void Remove(PollMentorAnswer pollMentorAnswer);
    }
}
