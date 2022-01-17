using System.Web.Mvc;
using PracticeManagement.Core;
using System.Collections.Generic;
using PracticeManagement.Core.ViewModel;
using PracticeManagement.Core.Models;
using Microsoft.AspNet.Identity;
using System.Linq;

namespace PracticeManagement.Controllers
{
    /// <summary>
    /// author: Grgo Jelavic
    /// description: implements interships logic
    /// date: 08.01.2022.
    /// </summary>
    [Authorize(Roles = RoleName.FaksAdminRoleName + "," + RoleName.ProfesorRoleName + "," + RoleName.AdministratorRoleName + "," + RoleName.StudentRoleName + "," + RoleName.MentorRoleName)]
    public class InternshipsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public InternshipsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Gets all internships and returns internship index page view
        /// </summary>
        /// <returns>Index view</returns>
        public ActionResult Index()
        {
            var Internships = _unitOfWork.Internships.GetInternships();
            return View(Internships);
        }
        /// <summary>
        /// Gets internship and returns internship detail page view
        /// </summary>
        /// <returns>Details view</returns>
        public ActionResult Details(int id)
        {
            var viewModel = new InternshipDetailViewModel()
            {
                Internship = _unitOfWork.Internships.GetInternship(id)
            };
            return View("Details", viewModel);
        }
        [Authorize(Roles = RoleName.FaksAdminRoleName + "," + RoleName.AdministratorRoleName + "," + RoleName.ProfesorRoleName)]

        /// <summary>
        /// Gets all internships and returns internship edit page view
        /// </summary>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            var Internship = _unitOfWork.Internships.GetInternship(id);
            if (Internship == null) return HttpNotFound();

            var viewModel = new InternshipFormViewModel()
            {
                Name = Internship.Name,
                Description = Internship.Description,
                Plan = Internship.Plan,
                Criteria = Internship.Criteria,
                Type = Internship.Type,
                Size = Internship.Size,
                Profesor = Internship.ProfessorID,
                YearOfStudy = Internship.YearID,
                FacultyCourse = Internship.CourseID,
                Status = Internship.Status,
                FacultyCourses = _unitOfWork.FacultyCourses.GetFacultyCourses(),
                Profesors = _unitOfWork.Profesors.GetProfesors(),
                YearOfStudies = _unitOfWork.YearOfStudies.GetYearOfStudies()
            };
            return View(viewModel);
        }

        /// <summary>
        /// Gets all internships and returns internship form page view
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = RoleName.FaksAdminRoleName + "," + RoleName.AdministratorRoleName + "," + RoleName.ProfesorRoleName)]
        [HttpPost]
        public ActionResult Edit(InternshipFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {

                viewModel.Profesors = _unitOfWork.Profesors.GetProfesors();
                viewModel.FacultyCourses = _unitOfWork.FacultyCourses.GetFacultyCourses();
                viewModel.YearOfStudies = _unitOfWork.YearOfStudies.GetYearOfStudies();
                return View(viewModel);
            }
            var InternshipInDb = _unitOfWork.Internships.GetInternship(viewModel.Id);
            InternshipInDb.Id = viewModel.Id;
            InternshipInDb.Name = viewModel.Name;
            InternshipInDb.Description = viewModel.Description;
            InternshipInDb.Plan = viewModel.Plan;
            InternshipInDb.Criteria = viewModel.Criteria;
            InternshipInDb.Type = viewModel.Type;
            InternshipInDb.Size = viewModel.Size;
            InternshipInDb.ProfessorID = viewModel.Profesor;
            InternshipInDb.YearID = viewModel.YearOfStudy;
            InternshipInDb.CourseID = viewModel.FacultyCourse;
            InternshipInDb.Status = viewModel.Status;

            _unitOfWork.Complete();
            
            return RedirectToAction("Details", new { id = viewModel.Id });
        }

        /// <summary>
        /// Gets all data and returns internship form page view
        /// </summary>
        /// <returns><internshipForm/returns>
        public ActionResult Create()
        {
            var viewModel = new InternshipFormViewModel
            {
                Profesors = _unitOfWork.Profesors.GetProfesors(),
                YearOfStudies = _unitOfWork.YearOfStudies.GetYearOfStudies(),
                FacultyCourses = _unitOfWork.FacultyCourses.GetFacultyCourses()
            };
            return View("InternshipForm", viewModel);
        }

        /// <summary>
        /// Gets all internships and returns internship form page view
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = RoleName.FaksAdminRoleName + "," + RoleName.AdministratorRoleName + "," + RoleName.ProfesorRoleName)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InternshipFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Profesors = _unitOfWork.Profesors.GetProfesors();
                viewModel.YearOfStudies = _unitOfWork.YearOfStudies.GetYearOfStudies();
                viewModel.FacultyCourses = _unitOfWork.FacultyCourses.GetFacultyCourses();
                 return View("InternshipForm", viewModel);
            }
            var internship = new Internship
            {
                Name = viewModel.Name,
                Description = viewModel.Description,
                Plan = viewModel.Plan,
                Criteria = viewModel.Criteria,
                Type = viewModel.Type,
                Size = viewModel.Size,
                ProfessorID = viewModel.Profesor,
                CourseID = viewModel.FacultyCourse,
                YearID = viewModel.YearOfStudy,
                Status = viewModel.Status
            };

            _unitOfWork.Internships.Add(internship);
            _unitOfWork.Complete();
            return RedirectToAction("Index", "Internships");
        }

        public ActionResult Update(int id)
        {
            var Internship = _unitOfWork.Internships.GetInternship(id);
            if (Internship == null) return HttpNotFound();

            var viewModel = new InternshipFormViewModel()
            {
                Id = Internship.Id,
                Name = Internship.Name,
                Description = Internship.Description,
                Plan = Internship.Plan,
                Criteria = Internship.Criteria,
                Type = Internship.Type,
                Size = Internship.Size,
                Profesor = Internship.ProfessorID,
                FacultyCourse = Internship.CourseID,
                YearOfStudy = Internship.YearID,
                Status = Internship.Status,
                Profesors = _unitOfWork.Profesors.GetProfesors(),
                YearOfStudies = _unitOfWork.YearOfStudies.GetYearOfStudies(),
                FacultyCourses = _unitOfWork.FacultyCourses.GetFacultyCourses(),
            };
            return View(viewModel);
        }
        /// <summary>
        /// Updates internship
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = RoleName.FaksAdminRoleName + "," + RoleName.AdministratorRoleName + "," + RoleName.ProfesorRoleName)]
        [HttpPost]
        public ActionResult Update(InternshipFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Profesors = _unitOfWork.Profesors.GetProfesors();
                viewModel.YearOfStudies = _unitOfWork.YearOfStudies.GetYearOfStudies();
                viewModel.FacultyCourses = _unitOfWork.FacultyCourses.GetFacultyCourses();
                return View(viewModel);
            }

            var IntenrshipInDb = _unitOfWork.Internships.GetInternship(viewModel.Id);
            IntenrshipInDb.Id = viewModel.Id;
            IntenrshipInDb.Name = viewModel.Name;
            IntenrshipInDb.Description = viewModel.Description;
            IntenrshipInDb.Plan = viewModel.Plan;
            IntenrshipInDb.Criteria = viewModel.Criteria;
            IntenrshipInDb.Type = viewModel.Type;
            IntenrshipInDb.Size = viewModel.Size;
            IntenrshipInDb.ProfessorID = viewModel.Profesor;
            IntenrshipInDb.CourseID = viewModel.FacultyCourse;
            IntenrshipInDb.YearID = viewModel.YearOfStudy;
            IntenrshipInDb.Status = viewModel.Status;
            _unitOfWork.Complete();

            return RedirectToAction("Index", "Internships");
        }

        /// <summary>
        /// Toggle internship status
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = RoleName.FaksAdminRoleName + "," + RoleName.AdministratorRoleName + "," + RoleName.ProfesorRoleName)]
        [HttpPost]
        public ActionResult ToggleStatus(int id)
        {
            var internship = _unitOfWork.Internships.GetInternship(id);
            if (internship.Status == 1) internship.Status = 0;
            else internship.Status = 1;
            _unitOfWork.Complete();
            return RedirectToAction("Index", "Internships");
        }
    }
}