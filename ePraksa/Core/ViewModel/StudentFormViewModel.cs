using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PracticeManagement.Core.Models;
using PracticeManagement.Controllers;
using PracticeManagement.Core.Helpers;
//using PracticeManagement.Core.Models;
using System.Linq.Expressions;
using System.Web.Mvc;
using System;

namespace PracticeManagement.Core.ViewModel {
    public class StudentFormViewModel {
        public int Id { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int Faculty { get; set; }
        [Required]
        public int FacultyCourse { get; set; }
        [Required]
        public int YearOfStudy { get; set; }
        [Required]
        public byte City { get; set; }
        //public int IsActive { get; set; }
        public string CV { get; set; }
        public int Active { get; set; }
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<Faculty> Faculties { get; set; }
        public IEnumerable<FacultyCourse> FacultyCourses { get; set; }
        public IEnumerable<YearOfStudy> YearOfStudies { get; set; }
        public IEnumerable<City> Cities { get; set; }
        public RegisterViewModel RegisterViewModel { get; set; }


        public string Action
        {
            get
            {
                Expression<Func<StudentsController, ActionResult>> update = (c => c.Update(this));
                Expression<Func<StudentsController, ActionResult>> create = (c => c.Create(this));

                var action = (Id != 0) ? update : create;
                return (action.Body as MethodCallExpression).Method.Name;

            }
        }
    }
}