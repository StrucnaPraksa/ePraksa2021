using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PracticeManagement.Core.Models;
using PracticeManagement.Core.Repositories;

namespace PracticeManagement.Persistence.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        public readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        ///// <returns></returns>
        //public IEnumerable<Faculty> GetFaculties()
        //{
        //    return _context.Faculties.ToList();
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Student> GetStudents()
        {

            return _context.Students
              .Include(c => c.City)
              .Include(fc => fc.Faculty)
              .Include(f => f.FacultyCourses)
              .Include(t => t.YearOfStudies)
              .ToList();
        }


        /// <summary>
        /// Da li se 
        /// </summary>
        /// <returns></returns>
        /*public IEnumerable<Student> GetStudent()
        {
            return _context.Students
                .Include(s => s.FacultyCourses)
                .Include(c => c.City)
                .Include(fc => fc.Faculty)
                .Include(u => u.YearsOfStudy)
                .ToList();
        }*/

        /// <summary>
        /// Get single Faculty - Admin
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Student GetStudent(int StudentId)
        {
            return _context.Students
                .Include(c => c.City)
                .Include(fc => fc.Faculty)
                .Include(s => s.FacultyCourses)
                .Include(u => u.YearOfStudies)
                .SingleOrDefault(d => d.Id == StudentId);
        }

        /// <summary>
        /// Add new patient
        /// </summary>
        /// <param name="student"></param>
        public void Add(Student student)
        {
            _context.Students.Add(student);
        }
        /// <summary>
        /// Delete existing patient
        /// </summary>
        /// <param name="student"></param>
        public void Remove(Student student)
        {
            _context.Students.Remove(student);
        }
    }
}