using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using PracticeManagement.Core.Models;
using PracticeManagement.Core.Repositories;

namespace PracticeManagement.Persistence.Repositories
{
    /// <summary>
    /// author: Grgo Jelavic
    /// description: implements interface IInternshipRepository
    /// date: 20.12.2021.
    /// </summary>
    public class InternshipRepository : IInternshipRepository
    {
        public readonly ApplicationDbContext _context;
        public InternshipRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets all Interships 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Internship> GetInternships()
        {
            return _context.Internships
              .Include(b => b.Profesors)
              .Include(c => c.FacultyCourses)
              .Include(d => d.YearOfStudies)
              .ToList();
        }

        /// <summary>
        /// Gets Internship details - Admin only, Others only if internship is activated
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Internship GetInternship(int Id)
        {
            return _context.Internships
                .Include(b => b.Profesors)
                .Include(c => c.FacultyCourses)
                .Include(d => d.YearOfStudies)
                .SingleOrDefault(e => e.Id == Id);
        }

        /// <summary>
        /// Add new Internship - Admin only
        /// </summary>
        /// <param name="internship"></param>
        public void Add(Internship internship)
        {
            _context.Internships.Add(internship);
        }
    }
}