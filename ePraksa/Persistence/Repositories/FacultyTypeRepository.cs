using PracticeManagement.Core.Models;
using PracticeManagement.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace PracticeManagement.Persistence.Repositories
{
    public class FacultyTypeRepository : IFacultyTypeRepository
    {
        public readonly ApplicationDbContext Context;

        public FacultyTypeRepository(ApplicationDbContext context)
        {
            Context = context;
        }

        public IEnumerable<FacultyType> GetFacultyTypes()
        {
            return Context.FacultyTypes.ToList();
        }
    }
}