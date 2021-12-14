
using System.Web.Mvc;
using PracticeManagement.Core;
using PracticeManagement.Core.ViewModel;
using PracticeManagement.Core.Models;
using Microsoft.AspNet.Identity;

namespace PracticeManagement.Controllers
{
    [Authorize(Roles = RoleName.FaksAdminRoleName + "," + RoleName.ProfesorRoleName + "," + RoleName.AdministratorRoleName + "," + RoleName.StudentRoleName + "," + RoleName.MentorRoleName)]
    public class StudentsController : Controller {

        private readonly IUnitOfWork _unitOfWork;

        public StudentsController(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index() {
            var Students = _unitOfWork.Students.GetStudents();
            return View(Students);
        }

        public ActionResult Details(int id) {
            var viewModel = new StudentDetailViewModel() {
                Student = _unitOfWork.Students.GetStudent(id)
            };
            return View("Details", viewModel);
        }
        //[Authorize(Roles = RoleName.FaksAdminRoleName + "," + RoleName.AdministratorRoleName + "," + RoleName.ProfesorRoleName + "," + RoleName.StudentRoleName)]
        public ActionResult Edit(int id) {
            var Student = _unitOfWork.Students.GetStudent(id);
            if (Student == null) return HttpNotFound();

            var viewModel = new StudentFormViewModel() {
                Id = Student.Id,
                Firstname = Student.Firstname,
                Lastname = Student.Lastname,
                Email = Student.Email,
                City = Student.CityID,
                FacultyCourse = Student.FacultyCourseId,
                Faculty = Student.FacultyID,
                YearOfStudy = Student.YearOfStudyID,
                CV = Student.CV,
                Active = Student.Active,
                Cities = _unitOfWork.Cities.GetCities(),
                YearOfStudies = _unitOfWork.YearOfStudies.GetYearOfStudies(),
                Faculties = _unitOfWork.Faculties.GetFaculties(),
                FacultyCourses = _unitOfWork.FacultyCourses.GetFacultyCourses()
            };
            return View(viewModel);
        }
        //[Authorize(Roles = RoleName.FaksAdminRoleName + "," + RoleName.AdministratorRoleName + "," + RoleName.ProfesorRoleName + "," + RoleName.StudentRoleName)]
        [HttpPost]
        public ActionResult Edit(StudentFormViewModel viewModel) {
            if (!ModelState.IsValid) {
                viewModel.Faculties = _unitOfWork.Faculties.GetFaculties();
                viewModel.Cities = _unitOfWork.Cities.GetCities();
                viewModel.FacultyCourses = _unitOfWork.FacultyCourses.GetFacultyCourses();
                viewModel.YearOfStudies = _unitOfWork.YearOfStudies.GetYearOfStudies();
                return View(viewModel);
            }

            var StudentInDb = _unitOfWork.Students.GetStudent(viewModel.Id);
            StudentInDb.Id = viewModel.Id;
            StudentInDb.Firstname = viewModel.Firstname;
            StudentInDb.Lastname = viewModel.Lastname;
            StudentInDb.Email = viewModel.Email;
            StudentInDb.CityID = viewModel.City;
            StudentInDb.FacultyID = viewModel.Faculty;
            StudentInDb.FacultyCourseId = viewModel.FacultyCourse;
            StudentInDb.YearOfStudyID = viewModel.YearOfStudy;
            StudentInDb.CV = viewModel.CV;
            StudentInDb.Active = viewModel.Active;

            _unitOfWork.Complete();

            return RedirectToAction("Details", new { id = viewModel.Id });
        }

        //[Authorize]
        public ActionResult Create() {
            var viewModel = new StudentFormViewModel {
                YearOfStudies = _unitOfWork.YearOfStudies.GetYearOfStudies(),
                FacultyCourses = _unitOfWork.FacultyCourses.GetFacultyCourses(),
                Cities = _unitOfWork.Cities.GetCities(),
                Faculties = _unitOfWork.Faculties.GetFaculties()
            };
            return View("StudentForm", viewModel);
        }
        //[Authorize(Roles = RoleName.FaksAdminRoleName + "," + RoleName.AdministratorRoleName + "," + RoleName.ProfesorRoleName + "," + RoleName.StudentRoleName)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentFormViewModel viewModel) {
            if (!ModelState.IsValid) {
                viewModel.YearOfStudies = _unitOfWork.YearOfStudies.GetYearOfStudies();
                viewModel.FacultyCourses = _unitOfWork.FacultyCourses.GetFacultyCourses();
                viewModel.Cities = _unitOfWork.Cities.GetCities();
                viewModel.Faculties = _unitOfWork.Faculties.GetFaculties();
                return View("StudentForm", viewModel);

            }
            var student = new Student {
                Firstname = viewModel.Firstname,
                Lastname = viewModel.Lastname,
                Email = viewModel.Email,
                Active = viewModel.Active,
                CityID = viewModel.City,
                FacultyID = viewModel.Faculty,
                FacultyCourseId = viewModel.FacultyCourse,
                YearOfStudyID = viewModel.YearOfStudy,
                CV = viewModel.CV
            };
          
            _unitOfWork.Students.Add(student);
            _unitOfWork.Complete();
            return RedirectToAction("Index", "Students");

        }

        public ActionResult Update(int id) {
                var Student = _unitOfWork.Students.GetStudent(id);
                if (Student == null) return HttpNotFound();

                var viewModel = new StudentFormViewModel() {
                    Id = Student.Id,
                    Firstname = Student.Firstname,
                    Lastname = Student.Lastname,
                    Email = Student.Email,
                    City = Student.CityID,
                    FacultyCourse = Student.FacultyCourseId,
                    Faculty = Student.FacultyID,
                    YearOfStudy = Student.YearOfStudyID,
                    Active = Student.Active,
                    Cities = _unitOfWork.Cities.GetCities(),
                    YearOfStudies = _unitOfWork.YearOfStudies.GetYearOfStudies(),
                    Faculties = _unitOfWork.Faculties.GetFaculties(),
                    FacultyCourses = _unitOfWork.FacultyCourses.GetFacultyCourses(),
                    CV = Student.CV
                };
                return View(viewModel);
            }
        //[Authorize(Roles = RoleName.FaksAdminRoleName + "," + RoleName.AdministratorRoleName + "," + RoleName.ProfesorRoleName + "," + RoleName.StudentRoleName)]
        [HttpPost]
        public ActionResult Update(StudentFormViewModel viewModel) {
            if (!ModelState.IsValid) {
                viewModel.Faculties = _unitOfWork.Faculties.GetFaculties();
                viewModel.Cities = _unitOfWork.Cities.GetCities();
                viewModel.FacultyCourses = _unitOfWork.FacultyCourses.GetFacultyCourses();
                viewModel.YearOfStudies = _unitOfWork.YearOfStudies.GetYearOfStudies();
                return View(viewModel);
            }

            var StudentInDb = _unitOfWork.Students.GetStudent(viewModel.Id);
            StudentInDb.Id = viewModel.Id;
            StudentInDb.Firstname = viewModel.Firstname;
            StudentInDb.Lastname = viewModel.Lastname;
            StudentInDb.Email = viewModel.Email;
            StudentInDb.CityID = viewModel.City;
            StudentInDb.FacultyID = viewModel.Faculty;
            StudentInDb.FacultyCourseId = viewModel.FacultyCourse;
            StudentInDb.YearOfStudyID = viewModel.YearOfStudy;
            StudentInDb.CV = viewModel.CV;
            _unitOfWork.Complete();

            return RedirectToAction("Index", "Students");
        }
    }

}