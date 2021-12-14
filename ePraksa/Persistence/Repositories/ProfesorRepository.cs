using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PracticeManagement.Core.Models;
using PracticeManagement.Core.Repositories;

namespace PracticeManagement.Persistence.Repositories
{
    public class ProfesorRepository : IProfesorRepository
    {
        private readonly ApplicationDbContext _context;
        public ProfesorRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public IEnumerable<Profesor> GetProfesor()
        {
            return _context.Profesors
                .Include(s => s.Specialization)
                .Include(u => u.Physician)
                .ToList();
        }

        /// <summary>
        /// Get the available Profesors
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Profesor> GetAvailableProfesors()
        {
            return _context.Profesors
                .Where(a => a.IsAvailable == true)
                .Include(s => s.Specialization)
                .Include(u => u.Physician)
                .ToList();
        }
        /// <summary>
        /// Get single Profesor - Admin
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Profesor GetProfesor(int id)
        {
            return _context.Profesors
                .Include(s => s.Specialization)
                .Include(u => u.Physician)
                .SingleOrDefault(d => d.Id == id);
        }

        public Profesor GetProfile(string userId)
        {
            return _context.Profesors
                .Include(s => s.Specialization)
                .Include(u => u.Physician)
                .SingleOrDefault(d => d.PhysicianId == userId);
        }
        public void Add(Profesor Profesor)
        {
            _context.Profesors.Add(Profesor);
        }

        public IEnumerable<Profesor> GetProfesors()
        {
            return _context.Profesors
                .Include(s => s.Specialization)
                .Include(u => u.Physician)
                .ToList();
        }
    }
}