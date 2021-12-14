using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PracticeManagement.Core.Models;
using PracticeManagement.Core.Repositories;

namespace PracticeManagement.Persistence.Repositories
{
    public class Faculty2Repository : IFaculty2Repository
    {
        public readonly ApplicationDbContext _context;

        public Faculty2Repository(ApplicationDbContext context)
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

        //public IEnumerable<Faculty2> GetFaculties2()
        //{
        //    return _context.Faculties2
        //        .Include(f => f.FacultySector)
        //      //   .Include(t => t.FacultyType)
        //        .ToList();
        //}

        public IEnumerable<Faculty2> GetFaculties2()
        {
            return _context.Faculties2
                .Include(f => f.FacultySector)
                //   .Include(t => t.FacultyType)
                .ToList();
        }


        /// <summary>
        /// Da li se 
        /// </summary>
        /// <returns></returns>
        //public IEnumerable<Faculty> GetFaculty2()
        //{
        //    return _context.Faculties2
        //        .Include(s => s.FacultyType)
        //        .Include(u => u.FacultySector)
        //        .ToList();
        //}




    }
}