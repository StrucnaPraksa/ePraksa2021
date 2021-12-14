using System.Collections.Generic;
using System.Linq;
using PracticeManagement.Core.Dto;
using PracticeManagement.Core.Models;
using PracticeManagement.Core.Repositories;

namespace PracticeManagement.Persistence.Repositories
{
    public class PracticeTypeRepository : IPracticeTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public PracticeTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<PracticeType> GetPracticeTypes()
        {
            return _context.PracticeTypes.ToList();
        }
    }
}