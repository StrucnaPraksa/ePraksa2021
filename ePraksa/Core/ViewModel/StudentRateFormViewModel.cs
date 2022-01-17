using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PracticeManagement.Core.Models;
using PracticeManagement.Controllers;
using PracticeManagement.Core.Helpers;
using System.Linq.Expressions;
using System.Web.Mvc;
using System;

namespace PracticeManagement.Core.ViewModel {

    public class StudentRateFormViewModel {

        public int Id { get; set; }
        public int MentorsID { get; set; }
        public int InternshipsID { get; set; }
        public int StudentsID { get; set; }
        //public Mentor Mentors { get; set; }
        //public int StudentsID { get; set; }
        //public Student Students { get; set; }
        // [Required]
        
        //zrinka
        [Required]
        public int A1 { get; set; }
        [Required]
        public int A2 { get; set; }
        [Required]
        public int A3 { get; set; }
        [Required]
        public int A4 { get; set; }
        [Required]
        public int A5 { get; set; }

        public bool Active { get; set; }
        [Required]
        public decimal Rate { get; set; }
        //public int PollMentorAnswer { get; set; }
       // public IEnumerable<PollMentorAnswer> PollMentorAnswers { get; set; }
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<Mentor> Mentors { get; set; }
        public IEnumerable<StudentRate> StudentRates { get; set; }
        public IEnumerable<Faculty> Faculties { get; set; }
        public IEnumerable<FacultyCourse> FacultyCourses { get; set; }
        public IEnumerable<YearOfStudy> YearOfStudies { get; set; }
        public IEnumerable<City> Cities { get; set; }
        public RegisterViewModel RegisterViewModel { get; set; }

        public string Action
        {
            get
            {
                Expression<Func<StudentRatesController, ActionResult>> update = (c => c.Update(this));
                Expression<Func<StudentRatesController, ActionResult>> create = (c => c.Create(this));
                //Expression<Func<StudentRatesController, ActionResult>> create = (c => c.Create(1));

                var action = (Id != 0) ? update : create;
                return (action.Body as MethodCallExpression).Method.Name;

           }
        }

        public IEnumerable<Internship> Internships { get; internal set; }
    }
}