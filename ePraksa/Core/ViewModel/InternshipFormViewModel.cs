using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PracticeManagement.Core.Models;
using PracticeManagement.Controllers;
using PracticeManagement.Core.Helpers;
using System.Linq.Expressions;
using System.Web.Mvc;
using System;

namespace PracticeManagement.Core.ViewModel
{
    /// <summary>
    /// author: Grgo Jelavic
    /// description: logic specifiication required to store and retreive data
    /// date: 08.01.2022.
    /// </summary>
    public class InternshipFormViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Plan { get; set; }
        public string Criteria { get; set; }
        [Required]
        public int FacultyCourse { get; set; }
        [Required]
        public int Profesor { get; set; }
        public string Type { get; set; }
        public string Size { get; set; }
        public int Status { get; set; }
        [Required]
        public int YearOfStudy { get; set; }
        public IEnumerable<YearOfStudy> YearOfStudies { get; set; }
        public IEnumerable<FacultyCourse> FacultyCourses { get; set; }
        public IEnumerable<Profesor> Profesors { get; set; }
        public RegisterViewModel RegisterViewModel { get; set; }
        public IEnumerable<Internship> Internships { get; set; }

        public string Action
        {
            get
            {
                Expression<Func<InternshipsController, ActionResult>> update = (c => c.Update(this));
                Expression<Func<InternshipsController, ActionResult>> create = (c => c.Create(this));

                var action = (Id != 0) ? update : create;
                return (action.Body as MethodCallExpression).Method.Name;
            }
        }
    }
}