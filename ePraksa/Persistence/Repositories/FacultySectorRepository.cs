using PracticeManagement.Core.Models;
using PracticeManagement.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace PracticeManagement.Persistence.Repositories
{
    public class FacultySectorRepository : IFacultySectorRepository
    {
        public readonly ApplicationDbContext Context;

        public FacultySectorRepository(ApplicationDbContext context)
        {
            Context = context;
        }

        public IEnumerable<FacultySector> GetFacultySectors()
        {
           return Context.FacultySectors.ToList();
        }
    }
}