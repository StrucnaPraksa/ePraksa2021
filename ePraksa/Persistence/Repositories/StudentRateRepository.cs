using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PracticeManagement.Core.Models;
using PracticeManagement.Core.Repositories;

namespace PracticeManagement.Persistence.Repositories
{
    public class StudentRateRepository : IStudentRateRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRateRepository(ApplicationDbContext context)
        {
            _context = context;
        }

         public IEnumerable<StudentRate> GetStudentRates()
         {

             return _context.StudentRates
                .Include(s => s.Students)
                .Include(s => s.Mentors)
                .Include(s => s.Internships)
                //.Include(c => c.City)
               // .Include(f => f.Faculties)
                //.Include(fc => fc.FacultyCourses)
                //.Include(u => u.YearOfStudies)
                .ToList();
         }
        /*public StudentRate GetStudentRated(int StudentRateId)
        {
            return _context.StudentRates
                .Include(s => s.Students)
                .Include(f => f.FacultyCourses)
                .Include(c => c.City)
                .Include(fc => fc.Faculty)
                .Include(u => u.YearOfStudies)
                .SingleOrDefault(d => d.Id == StudentRateId);
        }*/

        public StudentRate GetStudentRate(int id)
        {
            return _context.StudentRates
                //.Include(f => f.Students)
                //.Include(f => f.Firm)
                .SingleOrDefault(d => d.Id == id);
        }

        public void Add(StudentRate studentRate)
        {
            _context.StudentRates.Add(studentRate);
        }
        public void Remove(StudentRate studentRate)
        {
            _context.StudentRates.Remove(studentRate);
        }





        /* public IEnumerable<StudentRate> GetStudentRates()
         {
             return _context.StudentRates.ToList();
         }*/

        /*public IEnumerable<Student> GetStudent()
        {
            return _context.Students
                .Include(s => s.FacultyCourses)
                .Include(c => c.City)
                .Include(fc => fc.Faculty)
                .Include(u => u.YearsOfStudy)
                .ToList();
        }*/


    }
}