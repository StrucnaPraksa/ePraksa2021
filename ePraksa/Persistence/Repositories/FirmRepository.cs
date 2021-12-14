using PracticeManagement.Core.Models;
using PracticeManagement.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PracticeManagement.Persistence.Repositories
{
    public class FirmRepository : IFirmRepository
    {
        private readonly ApplicationDbContext _context;
        public FirmRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Firm> GetFirms()
        {
            return _context.Firms
                .Include(f => f.FirmAddress)
                .Include(f => f.FirmType)
                .ToList();
        }

        public Firm GetFirm(int id)
        {
            return _context.Firms.Find(id);
        }

        public void Add(Firm firm)
        {
            _context.Firms.Add(firm);
        }

        public void Remove(Firm firm)
        {
            _context.Firms.Remove(firm);
        }
    }
}