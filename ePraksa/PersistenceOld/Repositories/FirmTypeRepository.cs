using System.Collections.Generic;
using System.Linq;
using PracticeManagement.Core.Dto;
using PracticeManagement.Core.Models;
using PracticeManagement.Core.Repositories;

namespace PracticeManagement.Persistence.Repositories
{
    public class FirmTypeRepository : IFirmTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public FirmTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<FirmType> GetFirmTypes()
        {
            return _context.FirmTypes.ToList();
        }
    }
}