using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PracticeManagement.Core.Models;
using PracticeManagement.Core.Repositories;

namespace PracticeManagement.Persistence.Repositories
{
    public class FacultyRepository : IFacultyRepository
    {
        public readonly ApplicationDbContext _context;

        public FacultyRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// TODO: vidi čemu ovo služi
        /// </summary>
        ///// <returns></returns>
        //public IEnumerable<Faculty> GetFaculties()
        //{
        //    return _context.Faculties.ToList();
        //}

        public IEnumerable<Faculty> GetFaculties()
        {
            return _context.Faculties
                .Include(f => f.FacultySectors)
                .Include(t => t.FacultyTypes)
                .ToList();
        }


        /// <summary>
        /// Da li se 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Faculty> GetFaculty()
        {
            return _context.Faculties
                .Include(s => s.FacultyTypes)
                .Include(u => u.FacultySectors)
                .ToList();
        }

        /// <summary>
        /// Get single Faculty - Admin
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Faculty GetFaculty(int FacultyId)
        {
            return _context.Faculties
                .Include(s => s.FacultyTypes)
                .Include(u => u.FacultySectors)
                .SingleOrDefault(d => d.Id == FacultyId);
        }


    }
}