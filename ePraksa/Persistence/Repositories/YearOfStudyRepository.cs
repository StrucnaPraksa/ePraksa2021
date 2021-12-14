using PracticeManagement.Core.Models;
using PracticeManagement.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace PracticeManagement.Persistence.Repositories
{
    public class YearOfStudyRepository : IYearOfStudyRepository
    {
        public readonly ApplicationDbContext Context;

        public YearOfStudyRepository(ApplicationDbContext context)
        {
            Context = context;
        }

        public IEnumerable<YearOfStudy> GetYearOfStudies()
        {
           return Context.YearOfStudies.ToList();
        }
    }
}